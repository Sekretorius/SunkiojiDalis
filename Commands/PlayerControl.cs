using SignalRWebPack.Characters;
using SignalRWebPack.Hubs;
using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Managers;
using System;
using System.Collections.Generic;

namespace SignalRWebPack
{
    public class PlayerControl
    {
        private MessageHandler createHandler;

        private MessageHandler createGroupHandler;

        private MessageHandler selectHandler;

        private MessageHandler behaviorHandler;
        private List<ICommand> msgCommands;
        private StateManager controllCommandStateManager;
        private Controls playerControls;
        private Player player;

        private Group selected;



        public PlayerControl(Player player)
        {
            controllCommandStateManager = new StateManager();
            msgCommands = new List<ICommand>();
            playerControls = new Controls(player.getId(), false, false, false, false, false, false, false, false);
            this.player = player;

            if (createHandler == null)
                InitHandlers();

        }

        public void InitHandlers()
        {
            createGroupHandler = new MessageHandler(
                new CreateGroupExpression(
                    new TerminalExpression("Create group")
                ),CreateGroup
            );

            createHandler = new MessageHandler(
                new CreateExpression(
                    new TerminalExpression("Create npc"),
                    new List<IExpression>()
                    {
                        new TerminalExpression("Enemy"),
                        new TerminalExpression("Animal"),
                        new TerminalExpression("Friendly")
                    },
                    0, 100
                ),AddNpcsToGroup
            );

            selectHandler = new MessageHandler(
                new SelectExpression(
                    new TerminalExpression("Select")
                ),SelectNpcs
            );

            behaviorHandler = new MessageHandler(
                new BehaviorExpression(
                    new TerminalExpression("Behavior"),
                    new List<IExpression>()
                    {
                        new TerminalExpression("Walk"),
                        new TerminalExpression("Stand"),
                        new TerminalExpression("Fly")
                    }
                ),ChangeBehavior
            );

            createGroupHandler.SetNext(createHandler);
            createHandler.SetNext(selectHandler);
            selectHandler.SetNext(behaviorHandler);

        }
        public void MoveLeft()
        {
            ICommand command = new MoveLeftCommand(player);
            command.Execute();
        }
        public void MoveRight()
        {
            ICommand command = new MoveRightCommand(player);
            command.Execute();
        }
        public void MoveUp()
        {
            ICommand command = new MoveUpCommand(player);
            command.Execute();
        }
        public void MoveDown()
        {
            ICommand command = new MoveDownCommand(player);
            command.Execute();
        }

        public void Change()
        {
            ICommand command = new ChangeNPCCommand(player);
            command.Execute();
        }

        public void CheckInv()
        {
            ICommand command = new ChekInvCommand(player);
            command.Execute();
        }

        public void SendMessage(Message msg)
        {
            ICommand command = new MessageCommand(msg);
            command.Execute();
            msgCommands.Add(command);
        }

        public void UndoMsg()
        {
            if (msgCommands.Count > 0)
            {
                ICommand command = msgCommands[msgCommands.Count - 1];
                command.Undo();
                msgCommands.Remove(command);
            }
        }

        public void ChangeControls(Controls controls)
        {
            playerControls.Override(controls);
            
            if (controls.Undo)
            {
                playerControls.SetState(controllCommandStateManager.RestoreState());
                UndoControlls(playerControls);
            }
            else if (controls.UndoMsg)
            {
                player.control.UndoMsg();
            }
            else
            {
                ReadControlls(controls);
                controllCommandStateManager.StoreState(playerControls.SaveState());
            }
        }
        public void ReadControlls(Controls controls)
        {
            if (controls.Up)
            {
                player.control.MoveUp();
            }
            if (controls.Left)
            {
                player.control.MoveLeft();
            }
            if (controls.Down)
            {
                player.control.MoveDown();
            }
            if (controls.Right)
            {
                player.control.MoveRight();
            }
            if (controls.Change)
            {
                player.control.Change();
            }
            if (controls.CheckInv)
            {
                player.control.CheckInv();
            }
        }

        public void UndoControlls(Controls controls)
        {
            if (controls.Up)
            {
                (new MoveUpCommand(player)).Undo();
            }
            if (controls.Left)
            {
                (new MoveLeftCommand(player)).Undo();
            }
            if (controls.Down)
            {
                (new MoveDownCommand(player)).Undo();
            }
            if (controls.Right)
            {
                (new MoveRightCommand(player)).Undo();
            }
        }

        public void HandleMessage(string message)
        {
            createGroupHandler.Handle(message);
        }

        public void CreateNpcs(string msg)
        {
            string[] data = msg.Split(' ');
            NpcCreator npcCreator = new NpcCreator();
            for (int i = 0; i < int.Parse(data[2]); i++)
            {
                NPC npc = npcCreator.FactoryMethod(NpcType.Enemy, "default", player.GetGroupId());
                npc.SetMoveAlgorithm(new Walk());
                World.Instance.AddNPC(npc);
            }
        }

        public void ChangeBehavior(string msg)
        {
            if (selected == null)
                return;

            string[] data = msg.Split(' ');
            string groupName = data[1];

            MoveAlgorithm movement;

            if (data[1] == "stand")
                movement = new Stand();
            if (data[1] == "walk")
                movement = new Walk();
            else
                movement = new Fly();

            selected.SetBehavior(movement);
        }

        public void CreateGroup(string msg)
        {
            string[] data = msg.Split(' ');
            string childName = data[3];
            string parentName = data[2];
            Group group = World.Instance.GetGroup(player.worldX, player.worldY);
            Group target = group.GetGroup(parentName);
            if (target != null)
                target.Add(new Group(childName));
        }

        public void AddNpcsToGroup(string msg)
        {
            string[] data = msg.Split(' ');
            string groupName = data[2];
            string type = data[3];
            int count = int.Parse(data[4]);
            Group group = World.Instance.GetGroup(player.worldX, player.worldY);
            Group target = group.GetGroup(groupName);
            if (target == null)
                return;

            NpcType npcType = 0;
            switch (type.ToLower())
            {
                case "animal":
                    npcType = NpcType.Animal;
                    break;
                case "enemy":
                    npcType = NpcType.Enemy;
                    break;
                case "friendly":
                    npcType = NpcType.Friendly;
                    break;
            }
            NpcCreator npcCreator = new NpcCreator();
            for (int i = 0; i < count; i++)
            {
                NPC npc = npcCreator.FactoryMethod(npcType, "default", player.GetGroupId());
                npc.SetMoveAlgorithm(new Stand());
                target.Add(npc);
                World.Instance.AddNPC(npc);
            }
        }

        public void SelectNpcs(string msg)
        {
            string[] data = msg.Split(' ');
            string groupName = data[1];
            Group group = World.Instance.GetGroup(player.worldX, player.worldY);
            Group target = group.GetGroup(groupName);
            if (target != null)
                selected = target;
        }
    }
}
