using Furesoft.Signals;
using Topshelf;

namespace ExPay_Service
{
    internal class PaymentService : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            channel = Signal.CreateRecieverChannel("ExPay");
            Signal.CollectAllShared(channel);

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            channel = null;

            return true;
        }

        private IpcChannel channel;
    }
}