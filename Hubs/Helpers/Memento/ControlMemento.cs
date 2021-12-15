
using SignalRWebPack;
public class ControllMemento : IMemento<Controls>
{
    private int id;
    private bool up;
    private bool left;
    private bool down;
    private bool right;
    private bool change;
    private bool checkInv;

    public ControllMemento(int id, bool up, bool left, bool down, bool right, bool change, bool checkInv)
    {
        this.id = id;
        this.up = up;
        this.left = left;
        this.down = down;
        this.right = right;
        this.change = change;
        this.checkInv = checkInv;
    }

    public bool SetState(Controls org)
    {
        if(org.Id == id)
        {
            org.Up = up;
            org.Left = left;
            org.Down = down;
            org.Right = right;
            org.Change = change;
            org.CheckInv = checkInv;
            return true; 
        }
        return false;
    }
}