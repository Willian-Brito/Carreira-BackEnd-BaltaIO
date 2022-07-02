using System;

namespace EditorHtml
{
    public static class Menu
    {

        #region Metodos

        #region Show
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;

            DrawScreen();
            Opcoes();

            var opcao = short.Parse(Console.ReadLine());
            ManipularOpcaoMenu(opcao);
        }
        #endregion

        #region DrawScreen
        public static void DrawScreen()
        {
            Linha();

            for(int lines = 0; lines <= 10; lines++)
                Coluna();

            Linha();
        } 
        #endregion
        
        #region Linha
        private static void Linha()
        {
            Console.Write("+");

            for(int i = 0; i <= 30; i++)
                Console.Write("-");

            Console.Write("+");
            Console.Write("\n");
        }
        #endregion

        #region Coluna
        private static void Coluna()
        {

            Console.Write("|");

            for(int i = 0; i <= 30; i++)
                Console.Write(" ");    

            Console.Write("|");
            Console.Write("\n");   
        }
        #endregion

        #region Opcoes
        public static void Opcoes()
        {
            Console.SetCursorPosition(3, 2);
            System.Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(3, 3);
            System.Console.WriteLine("=====================");
            Console.SetCursorPosition(3, 4);
            System.Console.WriteLine("Selecione uma opção abaixo:");
            Console.SetCursorPosition(3, 6);
            System.Console.WriteLine("1 - Novo Arquivo");
            Console.SetCursorPosition(3, 7);
            System.Console.WriteLine("2 - Abrir Arquivo");
            Console.SetCursorPosition(3, 9);
            System.Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3, 10);
            System.Console.Write("Opção: ");
        }
        #endregion

        #region ManipularOpcaoMenu
        public static void ManipularOpcaoMenu(short opcoes)
        {
            switch(opcoes)
            {
                case 1: Editor.Show(); break;
                case 2: Editor.Abrir(); break;
                case 0: Sair(); break;
                default: Show(); break;
            }
        }
        #endregion

        #region Sair
        private static void Sair()
        {
            Console.Clear();
            Environment.Exit(0);
        }
        #endregion

        #endregion

    }
}