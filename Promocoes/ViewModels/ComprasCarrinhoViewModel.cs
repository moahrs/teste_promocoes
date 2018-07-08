using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Promocoes.MVC.ViewModels
{
    public class ComprasCarrinhoViewModel
    {
        [Key]
        public int prodID { get; set; }

        [DisplayName("Codigo")]
        public string codProd { get; set; }

        [DisplayName("Descricao")]
        public string descProd { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Preço de Venda")]
        public decimal precoProd { get; set; }

        [DisplayName("Quantidade")]
        public int qtdProd { get; set; }
    }
}