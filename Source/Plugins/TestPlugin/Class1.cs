using ExPay.Core.Contracts;
using System;
using System.Composition;
using System.Diagnostics;

namespace TestPlugin
{
    [Export(typeof(IMessageSender))]
    public class EmailSender : IMessageSender
    {
        public void Send(string message)
        {
            Debug.WriteLine(message);
        }
    }
}