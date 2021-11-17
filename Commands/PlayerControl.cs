using SignalRWebPack.Hubs;
using System.Collections.Generic;

namespace SignalRWebPack
{
    public class PlayerControl
    {
        private List<ICommand> commands;

        private List<ICommand> msgCommands;

        private Player player;
        public PlayerControl(Player player)
        {
            commands = new List<ICommand>();
            msgCommands = new List<ICommand>();
            this.player = player;
        }
        public void MoveLeft()
        {
            ICommand command = new MoveLeftCommand(player);
            command.Execute();
            commands.Add(command);
        }
        public void MoveRight()
        {
            ICommand command = new MoveRightCommand(player);
            command.Execute();
            commands.Add(command);
        }
        public void MoveUp()
        {
            ICommand command = new MoveUpCommand(player);
            command.Execute();
            commands.Add(command);
        }
        public void MoveDown()
        {
            ICommand command = new MoveDownCommand(player);
            command.Execute();
            commands.Add(command);
        }

        public void Change()
        {
            ICommand command = new ChangeNPCCommand(player);
            command.Execute();
            commands.Add(command);
        }

        public void CheckInv()
        {
            ICommand command = new ChekInvCommand(player);
            command.Execute();
            commands.Add(command);
        }

        public void SendMessage(Message msg)
        {
            ICommand command = new MessageCommand(msg);
            command.Execute();
            msgCommands.Add(command);
        }

        public void Undo()
        {
            if (commands.Count > 0)
            {
                ICommand command = commands[commands.Count-1];
                command.Undo();
                commands.Remove(command);
            }
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
    }
}
