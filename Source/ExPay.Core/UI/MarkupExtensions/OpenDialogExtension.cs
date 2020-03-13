using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExPay.Core.UI.Controls;
using System;
using System.Reflection;

namespace ExPay.Core.UI
{
    public class OpenDialogExtension : MarkupExtension
    {
        public OpenDialogExtension(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }
        public TimeSpan AutoCloseTime { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new DelegateCommand(_ =>
            {
                if (Type != null)
                {
                    var instance = Activator.CreateInstance(Type);
                    DialogService.OpenDialog((Control)instance, AutoCloseTime);
                }
            });
        }
    }
}