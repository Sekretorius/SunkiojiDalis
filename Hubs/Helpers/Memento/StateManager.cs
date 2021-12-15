using SignalRWebPack;
using System.Collections.Generic;
public class StateManager
{
    private List<IMemento<Controls>> stateHistory;
    private ListIterator<IMemento<Controls>> stateHistoryIterator;

    public StateManager()
    {
        stateHistory = new List<IMemento<Controls>>();
        stateHistoryIterator = new ListIterator<IMemento<Controls>>(stateHistory);
    }
    public IMemento<Controls> RestoreState()
    {
        if(stateHistoryIterator.Current() != null){
            IMemento<Controls> memento = stateHistoryIterator.Current();
            stateHistoryIterator.RemoveCurrent();
            stateHistoryIterator.Next();
            return memento;
        }
        return null;
    }

    public IMemento<Controls> GetState(int index)
    {
        if(stateHistory.Count > 0 && index >= 0)
        {
            return stateHistory[index];
        }
        return null;
    }

    public void StoreState(IMemento<Controls> memento)
    {
        stateHistory.Insert(0, memento);
    } 
}