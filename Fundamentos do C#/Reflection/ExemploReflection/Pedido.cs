using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploReflection
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; }

    }
}