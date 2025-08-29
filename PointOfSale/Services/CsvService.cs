using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Services
{
    public static class CsvService
    {
        public static List<Produto> CarregarProdutos(string caminhoCsv)

        {
            List<Produto> produtos = new List<Produto>();
            string[] linhas = File.ReadAllLines(caminhoCsv);

            foreach (var linha in linhas.Skip(1))
            {
                var partes = linha.Split(',');

                produtos.Add(new Produto(
                    int.Parse(partes[0]),
                    partes[1],
                    decimal.Parse(partes[2], CultureInfo.InvariantCulture),
                    int.Parse(partes[3])
                ));
            }

            return produtos;
        }

    }
}
