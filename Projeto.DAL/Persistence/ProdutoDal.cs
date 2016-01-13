using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Projeto.DAL.Util;
using Projeto.Entities;

namespace Projeto.DAL.Persistence
{
    public class ProdutoDal
    {
        public void Insert(Produto p)
        {    //Não é necessario dar new pois o objeto é statico
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Save(p);
                t.Commit();
            }
        }

        public void Update(Produto p)
        {    //Não é necessario dar new pois o objeto é statico
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Update(p);
                t.Commit();
            }
        }

        public void Delete(Produto p)
        {    //Não é necessario dar new pois o objeto é statico
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Delete(p);
                t.Commit();
            }
        }

        public List<Produto> FindAll()
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var query = from p in s.Query<Produto>()
                            select p;

                return query.ToList();
            }
        }

        public Produto FindById(int IdProduto)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var query = from p in s.Query<Produto>()
                            where p.IdProduto == IdProduto
                            select p;
                return query.FirstOrDefault();
            }
        }
    }

}
