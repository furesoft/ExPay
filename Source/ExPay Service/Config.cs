using DiscUtils.Registry;
using System;
using System.IO;

namespace ExPay_Service
{
    public static class Config
    {
        public static RegistryKey AppConfig;
        public static RegistryKey PaymentMethods;

        public static RegistryHive Hive { get; private set; }

        public static void Init()
        {
            if (File.Exists(ConfigFileName))
            {
                Hive = new RegistryHive(new FileStream(ConfigFileName, FileMode.OpenOrCreate));
            }
            else
            {
                Hive = RegistryHive.Create(ConfigFileName);
            }

            //init keys
            PaymentMethods = Hive?.Root.CreateSubKey("PaymentMethods");
            AppConfig = Hive?.Root.CreateSubKey("AppConfig");
        }

        public static void Reset()
        {
            File.Delete(ConfigFileName);
            Init();
        }

        private static string ConfigFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "expay.config");
    }
}