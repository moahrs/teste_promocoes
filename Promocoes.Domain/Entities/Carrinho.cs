using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promocoes.Domain.Entities
{
    public class Carrinho
    {
        public int prodID { get; set; }
        public string codProd { get; set; }
        public string descProd { get; set; }
        public decimal precoProd { get; set; }
        public int qtdProd { get; set; }
        public int PromocaoID { get; set; }
    }
}
