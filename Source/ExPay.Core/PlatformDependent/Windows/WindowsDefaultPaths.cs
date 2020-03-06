using ExPay.Core.PlatformDependent;
using System;
using System.IO;
using System.Reflection;

namespace ExPay.Implementation.Windows
{
    [PlattformImplementation(Platform.Windows)]
    public class WindowsDefaultPaths : IDefaultPath
    {
        public string PluginsPath => Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Plugins");

        public string SettingsPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Expay.config");
    }
}