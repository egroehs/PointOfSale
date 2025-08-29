using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    class ItemPedido
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal => Produto.Preco * Quantidade;

        public ItemPedido(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }

        public void AdicionarQuantidade(int quantidade)
        {
            Quantidade += quantidade;
        }
    }
}
