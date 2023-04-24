using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{

    /// <summary>
    //// Esse teste simula um pagamento de uma compra.
    //// O método PayOrder aceita diversas formas de pagamento. Dentro desse método é feita uma estrutura de diversos "if" para cada um deles.
    //// Ssabemos, no entanto, que esse formato não é adequado, em especial para futuras inclusões de formas de pagamento.
    //// Como você reestruturaria o método PayOrder para que ele ficasse mais aderente com as boas práticas de arquitetura de sistemas?

    [ApiController]
    [Route("[controller]")]
    public class Parte3Controller : ControllerBase
    {
        ////	[HttpGet("orders")]
        ////	public async Task<Order> PlaceOrder(string paymentMethod, decimal paymentValue, int customerId)
        ////	{
        ////		return await new OrderService().PayOrder(paymentMethod, paymentValue, customerId);
        ////	}
        ////}

        public interface IPaymentStrategy
        {
            bool Pay(decimal paymentValue, int customerId);
        }

        public class PixPaymentStrategy : IPaymentStrategy
        {
            public bool Pay(decimal paymentValue, int customerId)
            {
                //Faz o pagamento com Pix
                return true;
            }
        }

        public class CreditCardPaymentStrategy : IPaymentStrategy
        {
            public bool Pay(decimal paymentValue, int customerId)
            {
                //Faz o pagamento com cartão de crédito
                return true;
            }
        }

        public class PayPalPaymentStrategy : IPaymentStrategy
        {
            public bool Pay(decimal paymentValue, int customerId)
            {
                //Faz o pagamento com PayPal
                return true;
            }
        }

        public class OrderService
        {
            private readonly Dictionary<string, IPaymentStrategy> _paymentStrategies = new Dictionary<string, IPaymentStrategy>()
    {
        {"pix", new PixPaymentStrategy()},
        {"creditcard", new CreditCardPaymentStrategy()},
        {"paypal", new PayPalPaymentStrategy()}
    };

            public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
            {
                if (_paymentStrategies.TryGetValue(paymentMethod, out var paymentStrategy))
                {
                    if (paymentStrategy.Pay(paymentValue, customerId))
                    {
                        //Faz o pagamento
                        return new Order()
                        {
                            Value = paymentValue
                        };
                    }
                }

                throw new ArgumentException("Forma de pagamento inválida.");
            }
        }

    }
}