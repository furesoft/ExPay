namespace ExPay.Core
{
    public class Singleton<T> where T : class, new()

    {
        public static T Instance

        {
            get { return SingletonCreator.instance; }
            set { SingletonCreator.instance = value; }
        }

        private Singleton()
        { }

        private class SingletonCreator

        {
            static SingletonCreator()
            {
            }

            // Private object instantiated with private constructor

            internal static T instance = new T();
        }
    }
}