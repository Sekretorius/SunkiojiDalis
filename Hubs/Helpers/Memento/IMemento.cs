public interface IMemento<T>
{
    bool SetState(T org);
}