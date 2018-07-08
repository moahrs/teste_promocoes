using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Promocoes.MVC.ViewModels
{
    public class ProdutoPromocaoViewModel
    {
        [Key]
        public int PromocaoID { get; set; }

        public int ProdutoID { get; set; }

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