using System;

namespace StopWatch
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Start(int time)
        {
            int currentTime = 0;

            while(currentTime != time)
            {                
                Console.Clear();
                currentTime++;
                System.Console.WriteLine(currentTime);
                Thread.Sleep(1000);
            }

            Console.Clear();
            System.Console.WriteLine("Stopwatch finalizado!");
            Thread.Sleep(2500);
            Menu();
        }

        static void PreStart(int time)
        {
            Console.Clear();
            System.Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            System.Console.WriteLine("Set...");
            Thread.Sleep(1000);
            System.Console.WriteLine("Go...");
            Thread.Sleep(2500);

            Start(time);
        }

        static void Menu()
        {
            Console.Clear();
            System.Console.WriteLine("S - Segundos => 10s = 10 segundos");
            System.Console.WriteLine("M - Minutos => 1m = 1 minuto");
            System.Console.WriteLine("0 - Sair");
            System.Console.WriteLine("Quanto tempo deseja conta?");

            var dados = Console.ReadLine().ToLower();
            var ultimaPosicao = dados.Length - 1;

            char tipo = char.Parse(dados.Substring(ultimaPosicao, 1));
            int time = int.Parse(dados.Substring(0, dados.Length -1));
            int multiplicador = 1;

            if (tipo == 'm')
                multiplicador = 60;

            if (time == 0)
                System.Environment.Exit(0);

            PreStart(time * multiplicador);
        }
    }
}