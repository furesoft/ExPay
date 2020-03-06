using System.IO;

namespace ExPay.Core.PlatformDependent.Linux
{
    [PlattformImplementation(Platform.Linux)]
    public class LinuxDefaultPaths : IDefaultPath
    {
        public string PluginsPath => Path.Combine("/etc/ExPay");

        public string SettingsPath => "/etc/ExPay.config";
    }
}