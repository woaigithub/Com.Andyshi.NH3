using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Andyshi.NH3.Repositories
{
    public class CategoryRepository : Domain.ICategoryRepository
    {

        public void Add(Domain.Category  category)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    session.Save(category);
                    tran.Commit();
                }
            }
        }

        public void Update(Domain.Category category)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Category category)
        {
            throw new NotImplementedException();
        }

        public Domain.Category GetById(Guid categoryId)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                return session.Get<Domain.Category>(categoryId);
            }
        }

        public Domain.Category GetByName(string name)
        {
            throw new NotImplementedException();
        }




        public ICollection<Domain.Product> FindProducts(string category)
        {
            throw new NotImplementedException();
        }
    }
}
