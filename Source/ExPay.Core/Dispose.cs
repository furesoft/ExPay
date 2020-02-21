using System;
using System.Collections.Generic;
using System.Linq;

namespace ExPay.Core
{
    public static class Dispose
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static T New<T>()
            where T : IDisposable, new()
        {
            var instance = new T();
            Add(instance);

            return instance;
        }

        public static T New<T>(params object[] args)
             where T : IDisposable, new()
        {
            var type = typeof(T);
            var ctor = type.GetConstructor(args.Select(_ => _.GetType()).ToArray());
            var instance = (T)ctor.Invoke(args);

            return instance;
        }

        public static void AutomaticDispose(this IDisposable dis)
        {
            Add(dis);
        }

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