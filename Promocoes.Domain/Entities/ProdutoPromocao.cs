using System;

namespace Promocoes.Domain
{
    public class ProdutoPromocao
    {
        public int PromocaoID { get; set; }
        public int ProdutoID { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public Boolean Ativo { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
