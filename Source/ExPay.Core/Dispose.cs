using System;
using System.Collections.Generic;

namespace ExPay.Core
{
    public static class Dispose
    {
        public static void Add(IDisposable disposable)
        {
            _disposables.Add(disposable);
        }

        public static void DisposeAll()
        {
            foreach (var d in _disposables)
            {
                d.Dispose();
            }

            _disposables.Clear();
        }

        private static List<IDisposable> _disposables = new List<IDisposable>();
    }
}