using System.Text;
using System;

namespace EditorHtml
{
    public class Editor
    {
        #region Metodos
        
        #region Show
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("------------");
            
            Start();
        }   
        #endregion

        #region Start
        public static void Start()
        {
            
            var texto = LerTextoDigitado();

            Console.WriteLine("------------");
            Console.WriteLine(" Deseja salvar o arquivo ?");

            var resposta = Console.ReadLine().ToString();

            switch(resposta.ToUpper())
            {
                case "SIM":
                case "S": Salvar(texto); break;
                case "NAO":
                case "NÃO":
                case "N": Viewer.Show(texto.ToString()); break;
            }
        }
        #endregion

        #region Abrir
        public static void Abrir()
        {
            Console.Clear();
            System.Console.WriteLine("Qual caminho do arquivo?");
            string caminho = Console.ReadLine();

            using(var file = new StreamReader(caminho))
            {
                string texto = file.ReadToEnd();
                Console.WriteLine(texto);
            }

            Console.WriteLine("");
            Console.ReadLine();

            Menu.Show();
        }
        #endregion
        
        #region Salvar
        private static void Salvar(StringBuilder texto)
        {
            Console.Clear();
            System.Console.WriteLine(" Qual caminho para salvar o arquivo?");
            var caminho = Console.ReadLine();

            using(var file = new StreamWriter(caminho))
            {
                file.Write(texto);
            }

            Console.WriteLine($"Arquivo {caminho} salvo com sucesso!");
            Console.ReadLine();
            Menu.Show();
        }
        #endregion

        #region LerTextoDigitado
        private static StringBuilder LerTextoDigitado()
        {
            var NaoPressionarTeclaESC = false;
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);

                NaoPressionarTeclaESC = Console.ReadKey().Key != ConsoleKey.Escape;

            } while(NaoPressionarTeclaESC);

            return file;
        }
        #endregion

        #endregion
    }
}