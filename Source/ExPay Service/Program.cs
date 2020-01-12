using System;
using Topshelf;

namespace ExPay_Service
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<PaymentService>();
                x.EnableServiceRecovery(r => r.RestartService(TimeSpan.FromSeconds(10)));
                x.SetServiceName("ExPay");
                x.SetDescription("ExPay Payment Service");
                x.StartAutomatically();
            });
        }
    }
}