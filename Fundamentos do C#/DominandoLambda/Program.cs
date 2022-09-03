using System.Runtime.ConstrainedExecution;
using System.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DominandoLambda
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            try
            {
                int Qtde = 100000;

                System.Console.WriteLine("[+] Gerando Lista de Emlementos");
                var listaElementos = GerarListaElementos(Qtde);

                string tempoProcessamentoNormal = ProcessamentoNormalLINQ(listaElementos);
                string tempoProcessamentoParalelo = ProcessamentoParaleloLINQ(listaElementos);

                // string tempoProcessamentoNormal = ProcessamentoNormal(Qtde);
                // string tempoProcessamentoParalelo = ProcessamentoParalelo(Qtde);

                System.Console.WriteLine($"Tempo processamento paralelo: {tempoProcessamentoParalelo}");
                System.Console.WriteLine($"Tempo processamento normal: {tempoProcessamentoNormal}");

            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        #region Metodos

        #region PopularLista
        static List<int> GerarListaElementos(int Qtde)
        {
            List<int> listaElementos = new List<int>();
            Random valoresRandomicos = new Random();

            foreach (var valor in Enumerable.Range(1, Qtde).ToList())
                listaElementos.Add(valoresRandomicos.Next(Qtde));

            return listaElementos;
        }
        #endregion

        #region ProcessamentoParaleloLINQ
        private static string ProcessamentoParaleloLINQ(List<int> listaElementos)
        {
            var parallelsOptions = new ParallelOptions();
            parallelsOptions.MaxDegreeOfParallelism = 2;

            var tempoExecucao = new Stopwatch();

            tempoExecucao.Start();
            listaElementos.AsParallel().ForAll(item => 
            {
                System.Console.WriteLine($"Escrevendo a linha {item} na Thread: {Thread.CurrentThread.ManagedThreadId}");
            });
            // Parallel.ForEach(listaElementos, item => 
            // {
            //     System.Console.WriteLine($"Escrevendo a linha {item} na Thread: {Thread.CurrentThread.ManagedThreadId}");
            // }); 
            tempoExecucao.Stop();

            return tempoExecucao.Elapsed.ToString();
        }
        #endregion

        #region ProcessamentoNormalLINQ
        private static string ProcessamentoNormalLINQ(List<int> listaElementos)
        {
            var tempoExecucao = new Stopwatch();

            tempoExecucao.Start();
            listaElementos.ForEach(item => 
            {
                System.Console.WriteLine($"Escrevendo a linha {item} na Thread: {Thread.CurrentThread.ManagedThreadId}");
            });
            tempoExecucao.Stop();

            return tempoExecucao.Elapsed.ToString();
        }
        #endregion

        #region ProcessamentoParalelo
        private static string ProcessamentoParalelo(int qtde)
        {
            var tempoExecucao = new Stopwatch();

            tempoExecucao.Start();

            Parallel.For(0, qtde,index => {
                System.Console.WriteLine($"Escrevendo a linha {index}");
            });

            tempoExecucao.Stop();

            return tempoExecucao.Elapsed.ToString();
        }
        #endregion

        #region ProcessamentoNormal
        private static string ProcessamentoNormal(int qtde)
        {
            var tempoExecucao = new Stopwatch();

            tempoExecucao.Start();

            for (var i = 0; i < qtde; i++)
                System.Console.WriteLine($"Escrevendo a linha {i}");
            
            tempoExecucao.Stop();

            return tempoExecucao.Elapsed.ToString();
        }
        #endregion

        #endregion
    } 
}