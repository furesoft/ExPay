using Furesoft.Signals;
using System.Diagnostics;
using Topshelf;

namespace ExPay_Service
{
    internal class PaymentService : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            var channel = Signal.CreateRecieverChannel("ExPay");
            Signal.CollectAllShared(channel);

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }
    }
}