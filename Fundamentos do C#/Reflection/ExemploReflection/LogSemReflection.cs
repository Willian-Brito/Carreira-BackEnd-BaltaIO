using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploReflection
{
    public class LogSemReflection
    {
        public static void LogProdutos(Produto produto)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Log do produto");
            builder.AppendLine("Data: " + DateTime.Now);
            builder.AppendLine("Id: " + produto.Id);
            builder.AppendLine("Nome: " + produto.Nome);
            builder.AppendLine("Descrição: " + produto.Descricao);
            builder.AppendLine("Estoque: " + produto.Estoque);
            ImprimeLog(builder.ToString());
            //SalvaLog()
        }

        public static void LogPedidos(Pedido pedido)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Log do pedido");
            builder.AppendLine("Data: " + DateTime.Now);
            builder.AppendLine("Id: " + pedido.Id);
            builder.AppendLine("ClienteId: " + pedido.ClienteId);
            builder.AppendLine("DataPedido: " + pedido.DataPedido);
            ImprimeLog(builder.ToString());

        }

        public static void LogClientes(Cliente cliente)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Log do cliente");
            builder.AppendLine("Data: " + DateTime.Now);
            builder.AppendLine("Id: " + cliente.Id);
            builder.AppendLine("Nome: " + cliente.Nome);
            builder.AppendLine("Endereço: " + cliente.Endereco);
            ImprimeLog(builder.ToString());

        }

        public static void ImprimeLog(string texto)
        {
            Console.WriteLine(texto);
        }

        public void SalvaLog(string texto)
        {
            //salva o log
        }
    }
}