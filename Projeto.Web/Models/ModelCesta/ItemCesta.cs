using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Web.Models.ModelCesta
{
    public class ItemCesta
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal
        {
            get { return Quantidade * Preco; }
        }
        public string Foto { get; set; }
    }
}