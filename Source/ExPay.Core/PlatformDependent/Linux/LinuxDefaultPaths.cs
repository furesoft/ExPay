using System.IO;

namespace ExPay.Core.PlatformDependent.Linux
{
    [PlattformImplementation(Platform.Linux)]
    public class LinuxDefaultPaths : IDefaultPath
    {
        public string AppPath => "/usr/local/ExPay";
        public string PluginsPath => Path.Combine(AppPath, "Plugins");

        public string SettingsPath => "/etc/ExPay.config";
    }
}