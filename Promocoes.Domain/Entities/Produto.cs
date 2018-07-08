using System;
using System.Collections.Generic;

namespace Promocoes.Domain
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public String Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int PromocaoID { get; set; }
    }
}
