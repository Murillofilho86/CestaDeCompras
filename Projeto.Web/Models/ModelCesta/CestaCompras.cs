using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Web.Models.ModelCesta
{
    public class CestaCompras
    {
        public decimal ValorTotal
        {//Retirna o somatorio(sum) de cada valor total de cada item(i) da cesta
            get { return ItensCesta.Sum(i => i.ValorTotal); }
        }
        public int qtdItens
        {//Retorna o somatorio(sum) da quantidade de cada item(i) da cesta
            get { return ItensCesta.Sum(i => i.Quantidade); }
        }

        //Relacionamento
        public List<ItemCesta> ItensCesta { get; set; }
    }
}