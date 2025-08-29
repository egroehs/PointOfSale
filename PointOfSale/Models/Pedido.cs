using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.Services;

namespace PointOfSale
{
    class Pedido
    {
        private static int ProximoId = 1;

        public int Id { get; private set; }
        private Estoque Estoque;
        private List<ItemPedido> Itens;
        private bool Finalizado;


        public Pedido(Estoque estoque)
        {
            this.Id = ProximoId++;
            this.Estoque = estoque;
            this.Itens = new List<ItemPedido>();
            this.Finalizado = false;
        }

        public void AdicionarItem(int idProduto, int quantidade)
        {
            if (Finalizado)
            {
                Console.WriteLine("O pedido já foi finalizado.");
                return;
            }

            Produto produto = Estoque.BuscarProdutoPorId(idProduto);

            if(produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            if (produto.Quantidade < quantidade)
            {
                Console.WriteLine("Estoque insuficiente.");
                return;
            }

            ItemPedido itemExistente = Itens.FirstOrDefault(i => i.Produto.Id == idProduto);

            if(itemExistente != null)
            {
                itemExistente.AdicionarQuantidade(quantidade);
            }
            else
            {
                Itens.Add(new ItemPedido(produto, quantidade));
            }

            produto.Quantidade -= quantidade;

            Console.WriteLine($"Produto '{produto.Nome}' adicionado ao pedido.");
        }

        public void ExibirPedido()
        {
            if (!Itens.Any())
            {
                Console.WriteLine("O pedido está vazio.");
                return;
            }

            Console.WriteLine("\nItens do Pedido");
            Console.WriteLine("ID\t\tProduto\t\tQtd\t\tPreço\t\tSubtotal");

            foreach (var item in Itens)
            {
                Console.WriteLine($"{item.Produto.Id}\t\t{item.Produto.Nome}\t\t{item.Quantidade}\t\t{item.Produto.Preco:C}\t\t{item.Subtotal:C}");
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Total: {ObterTotal():C}\n");
        }

        public decimal ObterTotal()
        {
            return Itens.Sum(i => i.Subtotal);
        }

        public void FinalizarPedido(Pagamento pagamento, TrocoService trocoService)
        {
            if (!Itens.Any())
            {
                Console.WriteLine("Não é possível finalizar um pedido vazio.");
                return;
            }

            decimal total = ObterTotal();

            bool sucesso = pagamento.Processar(total, trocoService);
            if (sucesso)
            {
                Finalizado = true;
                Console.WriteLine("Pedido finalizado com sucesso!\n");
            }

        }

        public bool EstaFinalizado()
        {
            return Finalizado;
        }

    }

}
