using ExPay.Core.Contracts;
using Furesoft.Signals;
using Topshelf;

namespace ExPay_Service
{
    internal class PaymentService : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            Logger.Trace("Service started");

            WindowManager.Init();

            channel = Signal.CreateRecieverChannel("ExPay");
            Signal.CollectAllShared(channel);

            PluginLoader.Compose();

            foreach (var sender in PluginLoader.Instance.PaymentMethods)
            {
                sender.Initialize();
                Logger.Trace($"Payment Method '{sender.Info.Name}' initialized");
            }

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Logger.Trace("Service Stoped");

            channel.Dispose();
            channel = null;

            WindowManager.Shutdown();

            return true;
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private IpcChannel channel;
    }
}