using PointOfSale.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    class Pagamento
    {
        public decimal Troco { get; private set; }
        public string FormaPagamento { get; set; }
        public decimal ValorPago { set; get; }

        public Pagamento(string formaPagamento, decimal valorPago)
        {
            FormaPagamento = formaPagamento.ToLower();
            ValorPago = valorPago;
        }

        public bool Processar(decimal totalPedido, TrocoService trocoService)
        {
            if (FormaPagamento == "cartao")
            {
                Console.WriteLine($"Pagamento de {totalPedido:C} recebido no cartão.");
                return true;
            }
            else if (FormaPagamento == "dinheiro")
            {
                if (ValorPago < totalPedido)
                {
                    Console.WriteLine("Pagamento insuficiente.");
                    return false;
                }

                Troco = ValorPago - totalPedido;
                Console.WriteLine($"Pagamento em dinheiro recebido. Troco: {Troco:C}");
                trocoService.CalcularTroco(Troco);
                return true;
            }
            else
            {
                Console.WriteLine("Forma de pagamento inválida.");
                return false;
            }
        }
    }
}
