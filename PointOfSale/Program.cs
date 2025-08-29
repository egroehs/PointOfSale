using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.Services;

namespace PointOfSale
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminhoCsv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "baseProdutos.csv");
            var estoque = new Estoque(CsvService.CarregarProdutos("Data/baseProdutos.csv"));

            Caixa.MenuPrincipal(estoque);
        }
    }
}
