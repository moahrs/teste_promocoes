﻿using Promocoes.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Promocoes.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "Preencha o campo Codigo")]
        [MaxLength(20, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        [DisplayName("Codigo")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descricao")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        [DisplayName("Descricao")]
        public string Descricao { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Preencha com um Valor")]
        [DisplayName("Preço de Venda")]
        public decimal Preco { get; set; }

        public int PromocaoID { get; set; }

        public virtual ProdutoPromocao ProdutoPromocao { get; set; }
    }
}