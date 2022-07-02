using System.IO;
using System;


namespace TextEditor
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            System.Console.WriteLine("O que você deseja fazer ?");
            System.Console.WriteLine("1 - Abrir arquivo");
            System.Console.WriteLine("2 - Criar novo arquivo");
            System.Console.WriteLine("0 - Sair");

            short option = short.Parse(Console.ReadLine());

            switch(option)
            {
                case 0: Sair(); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }
        static void Abrir()
        {
            Console.Clear();
            System.Console.WriteLine("Qual caminho do arquivo?");
            string caminho = Console.ReadLine();

            using(var file = new StreamReader(caminho))
            {
                string texto = file.ReadToEnd();
                Console.WriteLine(texto);
            }

            System.Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }
        static void Editar() {

            Console.Clear();
            System.Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            System.Console.WriteLine("---------------------");

            string texto = "";
            var NaoPressionarESC = false;

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;

                NaoPressionarESC = Console.ReadKey().Key != ConsoleKey.Escape;
            }
            while(NaoPressionarESC);
            
            Salvar(texto);
        }
        static void Sair()
        {
            System.Environment.Exit(0);
        }
        static void Salvar(string texto)
        {
            Console.Clear();
            System.Console.WriteLine("Qual caminho para salvar o arquivo?");
            var caminho = Console.ReadLine();

            using(var file = new StreamWriter(caminho))
            {
                file.Write(texto);
            }

            System.Console.WriteLine($"Arquivo {caminho} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}