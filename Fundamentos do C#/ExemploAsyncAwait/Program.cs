using System;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        static async Task Main(string[] args)
        // public static void Main(string[] args)
        {
            Console.WriteLine(""); 
            Console.WriteLine("Tecle algo para iniciar \n");
            Console.ReadKey();

            // Aguardar(5);
            // AguardarAsync1(5);
            await AguardarAsync2(5); // se utilizar o await obrigatóriamente o metodo deve retornar uma Task

            Console.WriteLine("Já passou 5 segundos... \n");
            Console.WriteLine("Fim..");
            Console.ReadLine();
        }

        static void Aguardar(int tempo)
        {
            Console.WriteLine("Iniciando espera..");
            Task.Delay(TimeSpan.FromSeconds(tempo));
            Console.WriteLine("Fim da espera..");
        }

        static async void AguardarAsync1(int tempo)
        {
            Console.WriteLine("Iniciando espera..");
            await Task.Delay(TimeSpan.FromSeconds(tempo));
            Console.WriteLine("Fim da espera..");
        }

        static async Task AguardarAsync2(int tempo)
        {
            Console.WriteLine("Iniciando espera..");
            await Task.Delay(TimeSpan.FromSeconds(tempo));
            Console.WriteLine("Fim da espera..");
        }
    }

}
