using Avalonia.Media.Imaging;
using System.Threading.Tasks;

namespace ExPay.Core.Contracts
{
    public interface IPaymentMethod
    {
        Bitmap Image { get; }
        PaymentMethodInfo Info { get; }

        Task<object> BeforePay(object data);

        void Initialize();

        bool Invoke(object data);

        bool IsConfigured();
    }
}