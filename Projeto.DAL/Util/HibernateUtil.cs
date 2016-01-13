using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Projeto.DAL.Mapping;
using System.Configuration;

namespace Projeto.DAL.Util
{
    public class HibernateUtil
    {
        private static ISessionFactory fabrica;

        public static ISessionFactory GetSessionFactory()
        {
            if (fabrica == null)
            {
                fabrica = Fluently.Configure().Database(
                MsSqlConfiguration.MsSql2000.ConnectionString(
                            ConfigurationManager.ConnectionStrings["aula"].ConnectionString))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProdutoMap>())
                        .BuildSessionFactory();
            }

            return fabrica;
        }
    }

}
