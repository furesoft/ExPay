using Avalonia.Markup.Xaml;
using ExPay.Core.UI.Controls;
using System;

namespace ExPay.Core.UI.MarkupExtensions
{
    public class CloseDialogExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new DelegateCommand(_ => DialogService.CloseDialog());
        }
    }
}