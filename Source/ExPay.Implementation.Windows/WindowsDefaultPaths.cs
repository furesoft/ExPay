using ExPay.Core.PlatformDependent;
using System;

namespace ExPay.Implementation.Windows
{
    public class WindowsDefaultPaths : IDefaultPath
    {
        public string PluginsPath => throw new NotImplementedException();

        public string SettingsPath => throw new NotImplementedException();
    }
}