using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace Com.Andyshi.NH3.Repositories
{
    public class CategoryRepository : Domain.ICategoryRepository
    {

        public void Add(Domain.Category category)
        {
            using (var session = SessionManager.Instance.CreateSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    session.Save(category);
                    tran.Commit();
                }
            }
        }

        public Domain.Category First()
        {
            using (var session = SessionManager.Instance.CreateSession())
            {
                return session.QueryOver<Domain.Category>()
                              .Where(c => c.ModifyTime < DateTime.Now)
                              .List()
                              .FirstOrDefault();
                             

            }
        }
        public void Update(Domain.Category category)
        {
            using (var session = SessionManager.Instance.CreateSession())
            {
                session.SaveOrUpdate(category);
                session.Flush();
            }
        }
        public void Remove(Domain.Category category)
        {
            using (var session = SessionManager.Instance.CreateSession())
            {
                session.Delete(category);
                session.Flush();
            }
        }

        public Domain.Category GetById(Guid categoryId)
        {
            using (var session = SessionManager.Instance.CreateSession())
            {
                return session.Get<Domain.Category>(categoryId);
            }
        }

        public Domain.Category GetByName(string name)
        {
            using (var session = SessionManager.Instance.CreateSession())
            {
                return session.CreateCriteria<Domain.Category>()
                              .Add(NHibernate.Criterion.Restrictions.Eq("Name", name))
                              .UniqueResult<Domain.Category>();
            }
        }




        public ICollection<Domain.Product> FindProducts(Guid category)
        {
            using (var session = SessionManager.Instance.CreateSession())
            {
                return GetById(category).Products;
            }
        }
    }
}
