using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Services
{
    class TrocoService
    {
        private readonly decimal[] cedulas = { 200, 100, 50, 20, 10, 5, 2 };
        private readonly decimal[] moedas = { 1, 0.50m, 0.25m, 0.10m, 0.05m, 0.01m };

        public void CalcularTroco(decimal troco)
        {
            foreach(decimal cedula in cedulas)
            {
                int quantidadeCedulas = (int)(troco / cedula);

                if( quantidadeCedulas > 0)
                {
                    Console.WriteLine($"{quantidadeCedulas} x R${cedula}");
                    troco -= quantidadeCedulas * cedula;
                }
            }

            foreach (decimal moeda in moedas)
            {
                int quantidadeMoedas = (int)(troco / moeda);

                if (quantidadeMoedas > 0)
                {
                    Console.WriteLine($"{quantidadeMoedas} x R${moeda}");
                    troco -= quantidadeMoedas * moeda;
                }
            }
        }
    }
}
