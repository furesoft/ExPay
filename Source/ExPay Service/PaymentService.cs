using ExPay.Core;
using ExPay.Core.Contracts;
using ExPay.Core.Events;
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
            PaymentConfig.Init();

            channel = Signal.CreateRecieverChannel("ExPay");
            Signal.CollectAllShared(channel);

            Dispose.Add(channel);

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
            Signal.CallEvent(channel, new ConnectionLostEvent(ConnectionLostReason.Stoped));

            Dispose.DisposeAll();

            WindowManager.Shutdown();

            Logger.Trace("Service Stoped");

            return true;
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private IpcChannel channel;
    }
}