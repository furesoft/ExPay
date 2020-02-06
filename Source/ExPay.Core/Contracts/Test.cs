using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace ExPay.Core.Contracts
{
    public interface IMessageSender
    {
        void Send(string message);
    }

    public static class PluginLoader
    {
        [ImportMany]
        public static IEnumerable<IMessageSender> MessageSenders { get; set; }

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

            MessageSenders = container.GetExports<IMessageSender>();

            return container;
        }
    }

    [Export(typeof(IMessageSender))]
    public class EmailSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}