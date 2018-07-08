using Promocoes.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Promocoes.MVC.ViewModels
{
    public class ComprasViewModel
    {
        [Key]
        public int ProdutoID { get; set; }

        [DisplayName("Codigo")]
        public string Codigo { get; set; }

        [DisplayName("Descricao")]
        public string Descricao { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Preço de Venda")]
        public decimal Preco { get; set; }

        [DisplayName("Promocao")]
        public int PromocaoID { get; set; }

        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }

        public virtual ProdutoPromocao ProdutoPromocao { get; set; }
    }
}