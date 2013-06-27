using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Andyshi.NH3.Domain
{
    public interface ICategoryRepository
    {
        void Add(Category category);

        void Update(Category category);

        void Remove(Category category);

        Category GetById(Guid categoryId);

        Category GetByName(string name);

        ICollection<Product> FindProducts(Guid category);

       
    }
}
