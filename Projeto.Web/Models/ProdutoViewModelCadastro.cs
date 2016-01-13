using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Projeto.Web.Validators;

namespace Projeto.Web.Models
{
    public class ProdutoViewModelCadastro
    {
        [Required(ErrorMessage="Por favor informe o nome do produto")]
        [RegularExpression("^[A-Za-zÀ-Ü-à-ü0-9\\s]{5,50}$")]
        [Display(Name = "Nome do Produto:")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Por favor, informe o preco do produto")]
        [Range(1,Double.MaxValue,ErrorMessage="Preço do produto inválido.")]
        [Display(Name= "Preço do Produto:")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage="Por favor, envie a foto do produto.")]
        [FotoValidator(ErrorMessage="Erro. Envie apenas fotos JPG de até 1MB")]
        [Display(Name="Encie a Foto:")]
        public HttpPostedFileBase Foto { get; set; }
    }
}