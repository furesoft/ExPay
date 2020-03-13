using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExPay.Core.UI.Controls;
using System;

namespace ExPay.Core.UI
{
    public class OpenDialogExtension : MarkupExtension
    {
        public OpenDialogExtension(string typename)
        {
            Typename = typename;
        }

        public string Typename { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new DelegateCommand(_ =>
            {
                var type = Type.GetType(Typename);

                if (type != null)
                {
                    var instance = Activator.CreateInstance(type);
                    DialogService.OpenDialog((Control)instance);
                }
            });
        }
    }
}