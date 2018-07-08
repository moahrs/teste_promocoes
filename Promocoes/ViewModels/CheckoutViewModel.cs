using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Promocoes.MVC.ViewModels
{
    public class CheckoutViewModel
    {
        [DisplayName("Código")]
        public int Codigo { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }

        [DisplayName("Preço")]
        public decimal Preco { get; set; }
    }
}