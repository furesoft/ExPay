namespace ExPay.Core.Events
{
    public class ConnectionLostEvent : IServiceEvent
    {
        public ConnectionLostEvent(ConnectionLostReason reason)
        {
            Reason = reason;
        }

        public ConnectionLostReason Reason { get; set; }
    }

    public enum ConnectionLostReason
    {
        Stopped,
        Timeout,

    }
}