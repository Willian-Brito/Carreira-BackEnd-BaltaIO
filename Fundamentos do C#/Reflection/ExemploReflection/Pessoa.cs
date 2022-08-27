using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploReflection
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public decimal Altura { get; set; }
        public DateTime DataNascimento { get; set; }

        public void BuscarCaracteristicas()
        {
            Console.WriteLine($"Nome: {this.Nome}");
            Console.WriteLine($"Idade: {this.Idade}");
            Console.WriteLine($"Altura: {this.Altura}");
            Console.WriteLine($"DataNascimento: {this.DataNascimento}");
        }

        public void BuscarCaracteristicasComParametro(Pessoa pessoa)
        {
            Console.WriteLine($"Nome: {pessoa.Nome}");
            Console.WriteLine($"Idade: {pessoa.Idade}");
            Console.WriteLine($"Altura: {pessoa.Altura}");
            Console.WriteLine($"DataNascimento: {pessoa.DataNascimento}");
        }
    }
}



