using System;

namespace ExPay.Core.PlatformDependent
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PlattformImplementationAttribute : Attribute
    {
        public Platform Platform { get; set; }

        public PlattformImplementationAttribute(Platform platform)
        {
            Platform = platform;
        }
    }
}