using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploReflection
{
    public class LogComReflection
    {
        //método genérico para criar um log 
        //para qualquer classe
        public static void Log(object obj)
        {
            //obtem o tipo do objeto
            //esse tipo não tem relação com a instância de obj
            var tipo = obj.GetType();

            StringBuilder builder = new StringBuilder();
            //obtem o nome do tipo
            builder.AppendLine("Log do " + tipo.Name);
            builder.AppendLine("Data: " + DateTime.Now);

            //Vamos obter agora todas as propriedades do tipo
            //Usamos o método GetProperties para obter 
            //o nome das propriedades do tipo

            foreach (var prop in tipo.GetProperties())
            {
                //usa a propriedade Name para obter o nome da propriedade
                //e o método GetValue() para obter o valor da instância desse tipo
                builder.AppendLine(prop.Name + ": " + prop.GetValue(obj));
            }
            ImprimeLog(builder.ToString());
        }

        public static void ImprimeLog(string texto)
        {
            Console.WriteLine(texto);
        }
    }
}