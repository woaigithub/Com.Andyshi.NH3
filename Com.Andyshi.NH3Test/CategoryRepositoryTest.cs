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
        public void test_add_category_only()
        {
            var category = new Com.Andyshi.NH3.Domain.Category();
            category.Name = "category"+DateTime.Now.ToString();

            var categoryrepository = new Com.Andyshi.NH3.Repositories.CategoryRepository();
            categoryrepository.Add(category);

            var product = categoryrepository.GetById(category.ID);

            Assert.IsNotNull(product);

        }
    }
}
