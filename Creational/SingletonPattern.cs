using System;
namespace Creational
{
    public class SingletonClass
    {
        private static SingletonClass instance = null;
        private static object padLock = new object();
        private SingletonClass() { }

        public static SingletonClass getInstance()
        {
            if (instance == null)
            {
                lock (padLock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonClass();
                    }
                }
            }
            return instance;
        }
    }

    public class SingletonTest
    {
        public static void Test()
        {
            SingletonClass instance = SingletonClass.getInstance();
        }
    }
}