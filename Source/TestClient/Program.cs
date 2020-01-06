using Furesoft.Signals;
using System;

namespace TestClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var channel = Signal.CreateSenderChannel("ExPay");

            var result = Signal.CallMethod<int>(channel, 0x3A1);

            if (result == 1)
            {
                Console.WriteLine("Payment Succeed");
            }

            Console.ReadLine();
        }
    }
}