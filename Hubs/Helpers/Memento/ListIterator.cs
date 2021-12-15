using System.Collections.Generic;
public class ListIterator<T> : IITerator<T>
{
    private int index = 0;
    private List<T> itemList = new List<T>();

    public ListIterator(List<T> itemList)
    {
        this.itemList = itemList;
    }
    public IITerator<T> GetITerator()
    {
        return this;   
    }
    public T First()
    {
        if(itemList.Count > 0 && itemList.Count > index)
        {
            return itemList[0];
        }
        return default(T);
    }
    public T Next()
    {
        if(itemList.Count == 0 || itemList.Count <= index) return default(T);
        return itemList[index++];
    }
    public bool HasNext()
    {
        return itemList.Count > index + 1;
    }
    public void Reset()
    {
        index = 0;
    }
    public T Current()
    {
        if(itemList.Count > 0 && itemList.Count > index)
        {
            return itemList[index];
        }
        return default(T);
    }
    public void RemoveCurrent()
    {
        if(itemList.Count > 0 && itemList.Count > index)
        {
            itemList.Remove(itemList[index]);
        }

        if(itemList.Count > 0 && index > 0) index--;
        else index = 0;
    }
}