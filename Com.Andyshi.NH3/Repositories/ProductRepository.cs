using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Andyshi.NH3.Repositories
{
    public class ProductRepository : Domain.IProductRepository
    {
        public void Add(Domain.Product product)
        {
            //using (var session = NHibernateHelper.CreateSession())
            //{
            //    using (var tran = session.BeginTransaction())
            //    {
            //        session.Save(product);
            //        tran.Commit();
            //    }
            //}

            using (var session = NHibernateHelper.CreateSession())
            {

                session.Save(product);
                session.Flush();

            }
        }

        public void Update(Domain.Product product)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    session.Update(product);
                    tran.Commit();

                }
            }
        }

        public void Remove(Domain.Product product)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    session.Delete(product);
                    tran.Commit();
                }
            }
        }

        public Domain.Product GetById(Guid productId)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                return session.Get<Domain.Product>(productId);
            }
        }

        public Domain.Product GetByName(string name)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var product = session.CreateCriteria<Domain.Product>()
                    .Add(NHibernate.Criterion.Restrictions.Eq("Name", name))

                    .UniqueResult<Domain.Product>();
                return product;
            }
        }

        public ICollection<Domain.Product> GetByCategory(Guid category)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var products = session.CreateQuery("from Product");
                return products.Enumerable<Domain.Product>().ToList();
            }
        }
    }
}
