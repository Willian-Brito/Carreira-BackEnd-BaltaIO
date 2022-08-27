using System;
using System.Reflection;

namespace ExemploReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new Cliente()
            {
                Id = 10,
                Nome = "Willian Brito",
                Endereco = "Rua de teste, 0101"
            };

            var produto = new Produto()
            {
                Id = 1,
                Nome = "Cubo Magico",
                Descricao = "Cubo Magico 3x3",
                Estoque = 100,
                Preco = 63.99M
            };

            var pedido = new Pedido()
            {
                Id = 1,
                ClienteId = 1,
                DataPedido = DateTime.Now
            };

            var pessoa = new Pessoa()
            {
                Nome = "Monara Isabela Poli",
                Idade = 28,
                Altura = 1.65M,
                DataNascimento = Convert.ToDateTime("03/12/1993")
            };

            // Console.Clear();
            // Console.WriteLine("");
            // Console.WriteLine("***** Logando sem usar Reflection ****");
            // LogarSemReflection(cliente, produto, pedido);
            
            // Console.WriteLine(" ---------- Logando usando Reflection ----------");
            // LogarUsandoReflection(cliente, produto, pedido);
            // Console.ReadKey();

            // var resultado1 = SerializarObjetoParaJson(cliente);
            // var resultado2 = SerializarObjetoParaJson(pedido);
            // var resultado3 = SerializarObjetoParaJson(produto);
            Console.WriteLine("");

            pessoa.BuscarCaracteristicas();
            Console.WriteLine("");
            UtilizandoReflection(pessoa);


            
            Console.WriteLine("");

            // Console.WriteLine(resultado1);
            // Console.WriteLine("");
            // Console.WriteLine(resultado2);
            // Console.WriteLine("");
            // Console.WriteLine(resultado3);
            // Console.ReadKey();
        }

        public static void UtilizandoReflection(object obj)
        {
            var pessoa = Activator.CreateInstance(obj.GetType());
            var listaPropriedades = pessoa.GetType().GetProperties();

            foreach (var prop in listaPropriedades)
            {  
                if (prop.PropertyType == typeof(DateTime))
                {
                    prop.SetValue(pessoa, Convert.ToDateTime("01/05/1991"));
                }
                else if (prop.PropertyType == typeof(Decimal) || prop.PropertyType == typeof(Double))
                {
                    prop.SetValue(pessoa,1.80M);
                }
                else if (prop.PropertyType == typeof(Int32) || prop.PropertyType == typeof(Int64))
                {
                    prop.SetValue(pessoa, 31);
                }
                else
                {
                    prop.SetValue(pessoa, "Willian Ferreira Brito");
                }

                // Console.WriteLine( $"{prop.Name}: {prop.GetValue(obj)}");
            }
            
            // pessoa.GetType().InvokeMember("BuscarCaracteristicas", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, pessoa, null);

            pessoa.GetType().InvokeMember("BuscarCaracteristicasComParametro", 
                                           BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, 
                                           null, 
                                           pessoa, 
                                           new object[] { pessoa }
                                         );
        }

        public static void LogarSemReflection(Cliente cli, Produto prod, Pedido ped)
        {
            LogSemReflection.LogClientes(cli);
            LogSemReflection.LogProdutos(prod);
            LogSemReflection.LogPedidos(ped);
        }

        public static void LogarUsandoReflection(Cliente cli, Produto prod, Pedido ped)
        {
            LogComReflection.Log(cli);
            LogComReflection.Log(prod);
            LogComReflection.Log(ped);
        }

        public static string SerializarObjetoParaJson(object obj)
        {
            var valorSerializado = "";

            //Vamos obter agora todas as propriedades do tipo
            //Usamos o método GetProperties para obter 
            //o nome das propriedades do tipo
            foreach (var prop in obj.GetType().GetProperties())
            {
                //Usamos o método GetValue() para obter o valor da instância desse tipo
                var valor = prop.GetValue(obj);

                //agora verificamos o tipo de cada propriedade
                //para realizar a formatação adequada
                if (prop.PropertyType == typeof(DateTime))
                {
                    valorSerializado += "\"" + prop.Name + "\":" + "\"" + string.Format("{0:dd/MM/yyyy}", valor) + "\",";
                }
                else if (prop.PropertyType == typeof(Decimal) || prop.PropertyType == typeof(Double))
                {
                    valorSerializado += "\"" + prop.Name + "\":" + "\"" + string.Format("{0:N}", valor) + "\",";
                }
                else
                {
                    valorSerializado += "\"" + prop.Name + "\":" + "\"" + valor + "\",";
                }
            }

            valorSerializado = valorSerializado.Substring(1, valorSerializado.Length - 2);

            //retorna o objeto serializado
            return "{\"" + valorSerializado + "}";
        }

    }
}
