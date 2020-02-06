using ExPay.Core.Contracts;
using Furesoft.Signals;
using Topshelf;

namespace ExPay_Service
{
    internal class PaymentService : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            WindowManager.Init();

            channel = Signal.CreateRecieverChannel("ExPay");
            Signal.CollectAllShared(channel);

            PluginLoader.Compose();

            foreach (var sender in PluginLoader.Instance.PaymentMethods)
            {
                sender.Initialize();
            }

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            channel.Dispose();
            channel = null;

            return true;
        }

        private IpcChannel channel;
    }
}