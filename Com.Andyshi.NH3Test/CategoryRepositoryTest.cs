using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace Com.Andyshi.NH3Test
{
    [TestFixture]
    public  class CategoryRepositoryTest
    {

        [Test]
        public void add_new_test()
        {
            var category = new Com.Andyshi.NH3.Domain.Category();
            category.Name = "category1";

            var categoryrepository = new Com.Andyshi.NH3.Repositories.CategoryRepository();
            categoryrepository.Add(category);

            var product = categoryrepository.GetById(category.Id);

            Assert.IsNotNull(product);

        }
    }
}
