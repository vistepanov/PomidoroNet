namespace PomidoroInterfaces
{
    public interface IMessengerStatus
    {
        void SetStatus(MessengerStatus status);
        void SetText(string msg);
        void GetInitialStatus();
        void RestoreInitialStatus();
    }
}