using PointOfSale.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
   public static class Caixa
    {
        public static void MenuPrincipal(Estoque estoque)
        {
            Pedido pedidoAtual = new Pedido(estoque);
            TrocoService trocoService = new TrocoService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PEDIDO ===");
                Console.WriteLine("1 - Adicionar item");
                Console.WriteLine("2 - Exibir pedido");
                Console.WriteLine("3 - Realizar pagamento do pedido");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                if (opcao == "0")
                {
                    Console.WriteLine("Encerrando o sistema...");
                    break;  
                }

                switch (opcao)
                {
                    case "1":
                        Console.Write("ID do produto: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Quantidade: ");
                        int qtd = int.Parse(Console.ReadLine());

                        pedidoAtual.AdicionarItem(id, qtd);
                        break;

                    case "2":
                        pedidoAtual.ExibirPedido();
                        break;

                    case "3":
                        Console.WriteLine("Escolha a forma de pagamento:");
                        Console.WriteLine("1 - Dinheiro");
                        Console.WriteLine("2 - Cartão");
                        Console.Write("Opção: ");
                        string opcaoPagamento = Console.ReadLine();
                        string formaPagamento = "";
                        decimal valorPago = 0;

                        switch (opcaoPagamento)
                        {
                            case "1":
                                formaPagamento = "dinheiro";
                                Console.Write("Informe o valor pago: R$ ");
                                if (!decimal.TryParse(Console.ReadLine(), out valorPago))
                                {
                                    Console.WriteLine("Valor inválido. Pagamento cancelado.");
                                    break;
                                }
                                break;

                            case "2":
                                formaPagamento = "cartao";
                                break;

                            default:
                                Console.WriteLine("Opção inválida.");
                                break;
                        }

                        if (formaPagamento != "")
                        {
                            var pagamento = new Pagamento(formaPagamento, valorPago);
                            pedidoAtual.FinalizarPedido(pagamento, trocoService);

                            if (pedidoAtual.EstaFinalizado())
                            {
                                pedidoAtual = new Pedido(estoque);
                            }

                        }


                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

                Console.ReadKey();
            }

        }
    }
}
