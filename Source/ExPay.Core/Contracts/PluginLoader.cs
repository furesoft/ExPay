using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var executableLocation = Assembly.GetEntryAssembly().Location;
            var path = Path.Combine(Path.GetDirectoryName(executableLocation), "Plugins");

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

            return container;
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    }
}