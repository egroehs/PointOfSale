using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    public class Estoque
    {
        private List<Produto> produtos;

        public Estoque(List<Produto> produtos)
        {
            this.produtos = produtos;
        }

        public Produto BuscarProdutoPorId(int id)
        {
            return produtos.FirstOrDefault(p => p.Id == id);
        }

      
    }
}

