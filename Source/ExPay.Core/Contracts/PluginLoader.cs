using ExPay.Core.Models;
using ExPay.Core.PlatformDependent;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace ExPay.Core.Contracts
{
    public class PluginLoader
    {
        public static PluginLoader Instance = new PluginLoader();

        [ImportMany]
        public IEnumerable<IPaymentMethod> PaymentMethods { get; set; }

        public static CompositionHost Compose()
        {
            var path = Allocator.New<IDefaultPath>().PluginsPath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var assemblies = Directory
                        .GetFiles(path, "*.dll", SearchOption.AllDirectories)
                        .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                        .ToList();
            var configuration = new ContainerConfiguration()
                .WithAssemblies(assemblies);

            var container = configuration.CreateContainer();
            container.SatisfyImports(Instance);

            Logger.Trace("Plugins composed");

            return container;
        }

        public bool IsPaymentMethodAvailable(IEnumerable<PaymentMethodData> acceptedPaymentMethods)
        {
            PaymentConfig.Init();
            PaymentConfig.InitMethods(Instance.PaymentMethods);

            foreach (var pm in Instance.PaymentMethods)
            {
                if (PaymentConfig.IsConfigured(pm.Info.ID))
                {
                    if (pm.IsConfigured())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    }
}