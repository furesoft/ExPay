namespace ExPay.Core.PlatformDependent
{
    public interface IDefaultPath
    {
        string AppPath { get; }
        string PluginsPath { get; }
        string SettingsPath { get; }
    }
}