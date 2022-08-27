using System;

namespace ExampleDelegaqte
{
    public class Program
    {
        // # Callback
        static void ExibirStatusProcessamento(int numeroPedido)
        {
            Console.WriteLine($"Pedido N° {numeroPedido} processado!");
        }

        public static void Main(string[] args)
        {
            var pagamento = new Pagamento();

            // Exemplo 1
            pagamento.Processar(ExibirStatusProcessamento);

            // Exemplo 2
            pagamento.Processar(numeroPedido => 
            {
                Console.WriteLine($"Pedido N° {numeroPedido} processado!");
            });
        }
    }


    class Pagamento
    {
        public delegate void PagamentoProcessado(int numeroPedido);

        public void Processar(PagamentoProcessado pagamentoProcessado)
        {
            for (int i = 1; i <= 10; i++)
            {
                // # Simulando Pagamento
                Thread.Sleep(1000);

                // # Status Processamento
                pagamentoProcessado(i);            
            }
        }
    }
}   
