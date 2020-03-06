using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ExPay.Core.PlatformDependent
{
    public static class Allocator
    {
        public static T New<T>()
        {
            var currentPlatform = GetCurrentPlatform();
            var implementation = GetImplementationOf<T>(currentPlatform);

            return (T)Activator.CreateInstance(implementation);
        }

        public static IEnumerable<Platform> GetAvailablePlatformsForInstance<T>()
        {
            var ass = Assembly.GetEntryAssembly();
            var types = ass.GetTypes();

            foreach (var t in types)
            {
                if (t.IsInterface || t.IsAbstract) continue;
                else
                {
                    if (typeof(T).IsAssignableFrom(t) || t.IsInstanceOfType(typeof(T)))
                    {
                        var attr = t.GetCustomAttribute<PlattformImplementationAttribute>();
                        if (attr != null)
                        {
                            yield return attr.Platform;
                        }
                    }
                }
            }
        }

        private static Platform GetCurrentPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Platform.Windows;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Platform.Linux;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return Platform.OSX;
            }

            return Platform.Windows;
        }

        private static Type GetImplementationOf<T>(Platform currentPlatform)
        {
            var types = GetAllTypes();

            foreach (var t in types)
            {
                if (t.IsInterface || t.IsAbstract) continue;
                else
                {
                    if (typeof(T).IsAssignableFrom(t) || t.IsInstanceOfType(typeof(T)))
                    {
                        var attr = t.GetCustomAttribute<PlattformImplementationAttribute>();
                        if (attr != null)
                        {
                            if (attr.Platform == currentPlatform)
                            {
                                return t;
                            }
                        }
                    }
                }
            }

            throw new PlatformNotSupportedException();
        }

        private static IEnumerable<Type> GetAllTypes()
        {
            var res = new List<Type>();

            res.AddRange(Assembly.GetExecutingAssembly().GetTypes());
            res.AddRange(Assembly.GetCallingAssembly().GetTypes());
            res.AddRange(Assembly.GetEntryAssembly().GetTypes());

            return res;
        }
    }
}