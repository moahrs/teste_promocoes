using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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

        [DisplayName("Quantidade")]
        public string qtdProd { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Preço de Venda")]
        public decimal precoProd { get; set; }

        [DisplayName("Promoção")]
        public int PromocaoID { get; set; }

        public string descPromo { get; set; }
    }
}