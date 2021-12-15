public interface IITerator<T>
{
    IITerator<T> GetITerator();
    T First();
    T Next();
    bool HasNext();
    void Reset();
    void RemoveCurrent();
}