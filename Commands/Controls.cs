using Newtonsoft.Json;

namespace SignalRWebPack
{
    [JsonObject(MemberSerialization.Fields)]
    public class Controls
    {
        public int Id { get => id; set => id = value;}
        public bool Up  { get => up; set => up = value;}
        public bool Left { get => left; set => left = value;}
        public bool Down { get => down; set => down = value;}
        public bool Right { get => right; set => right = value;}
        public bool Change { get => change; set => change = value;}
        public bool CheckInv { get => checkInv; set => checkInv = value;}
        public bool Undo { get => undo; set => undo = value;}
        public bool UndoMsg { get => undoMsg; set => undoMsg = value;}
        
        private int id;
        private bool up;
        private bool left;
        private bool down;
        private bool right;
        private bool change;
        private bool checkInv;
        private bool undo;
        private bool undoMsg;

        public Controls(int id, bool up, bool left, bool down, bool right, bool change, bool checkInv, bool undo, bool undoMsg)
        {
            this.id = id;
            this.up = up;
            this.left = left;
            this.down = down;
            this.right = right;
            this.change = change;
            this.checkInv = checkInv;
        }
        public void Override(Controls controls)
        {
            this.up = controls.up;
            this.left = controls.left;
            this.down = controls.down;
            this.right = controls.right;
            this.change = controls.change;
            this.checkInv = controls.checkInv;
        }

        public void SetState(IMemento<Controls> state)
        {
            if(state != null)
                state.SetState(this);
        }
        public IMemento<Controls> SaveState()
        {
            return new ControllMemento(id, up, left, down, right, change, checkInv);
        }
    }
}