using System.Text.RegularExpressions;
using System;

namespace EditorHtml
{
    public class Viewer
    {
        #region Metodos
        
        #region Show
        public static void Show(string texto)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO VISUALIZAÇÃO");
            Console.WriteLine("------------");
            Substituir(texto);
            Console.WriteLine("------------");
            Console.ReadKey();

            Menu.Show();
        }
        #endregion

        #region Substituir
        private static void Substituir(string texto)
        {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            var palavras = texto.Split(" ");

            for(var i = 0; i < palavras.Length; i++)
            {
                if(strong.IsMatch(palavras[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    
                    var inicioTexto = palavras[i].IndexOf('>') + 1;
                    var finalTexto = (palavras[i].LastIndexOf('<') - 1) - palavras[i].IndexOf('>');

                    var resultado = palavras[i].Substring(inicioTexto, finalTexto);

                    Console.Write(resultado);
                    Console.Write(" ");
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Black;
                    Console.Write(palavras[i]);
                    Console.Write(" ");
                }
            }
        }
        #endregion

        #endregion
    }
}