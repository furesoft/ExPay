using System;
using System.Collections.Generic;
using System.Text;

namespace ExPay.Core
{
    public class Singleton<T> where T : class, new()

    {
        public static T Instance

        {
            get { return SingletonCreator.instance; }
        }

        private Singleton()
        { }

        private class SingletonCreator

        {
            static SingletonCreator()
            {
            }

            // Private object instantiated with private constructor

            internal static readonly T instance = new T();
        }
    }
}