using System;
using System.Collections.Generic;

namespace ExPay.Core
{
    public static class Dispose
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Add(IDisposable disposable)
        {
            _disposables.Add(disposable);
        }

        public static void DisposeAll()
        {
            foreach (var d in _disposables)
            {
                d.Dispose();
                Logger.Info($"{d.GetType().Name} disposed");
            }

            _disposables.Clear();
            Logger.Info("Disposechain cleared");
        }

        private static List<IDisposable> _disposables = new List<IDisposable>();
    }
}