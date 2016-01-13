using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projeto.Entities;

namespace Projeto.DAL.Mapping
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Table("Produto");

            Id(p => p.IdProduto, "IdProduto").GeneratedBy.Identity();
            Map(p => p.Nome, "Nome").Length(50).Not.Nullable();
            Map(p => p.Preco, "Preco").Not.Nullable();
            Map(p => p.DataCadastro, "DataCadastro").Not.Nullable();
            Map(p => p.Foto, "Foto").Length(50).Not.Nullable().Unique();
            
        }
    }
}
