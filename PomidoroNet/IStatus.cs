namespace PomidoroNet
{
    public enum MessengerStatus
    {
        Free,
        Busy,
        DoNotDisturb,
        Away
    }
    public interface IMessengerStatus
    {
        void SetStatus(MessengerStatus status);
    }
}