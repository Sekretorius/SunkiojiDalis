namespace SunkiojiDalis.Hubs.Worlds
{
    public interface IObserver
    {
        public void Update(string msg) { }
        public void NotifyServer(string msg) { }
    }
}