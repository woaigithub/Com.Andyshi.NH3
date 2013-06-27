using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Com.Andyshi.NH3.Domain;
using Com.Andyshi.NH3.Repositories;

namespace FirstSolution.Test
{
    [TestFixture]
    public class ProductRepository_Fixture
    {

        //private ISessionFactory _sessionFactory;
        //private Configuration _configuration;


        private ISession _session;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {

            _session = SessionManager.Instance.CreateSession();
        }

        [SetUp]
        public void SetupContext()
        {
            //new SchemaExport(_configuration).Execute(false, true, false);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            _session.Close();
        }


        [Test]
        public void add_product_with_category()
        {
            var category = new Com.Andyshi.NH3.Domain.Category();
            category.Name = "category1";

            var categoryrepository = new Com.Andyshi.NH3.Repositories.CategoryRepository();
            categoryrepository.Add(category);

            var product = new Com.Andyshi.NH3.Domain.Product();
            product.Name = "product1";
            product.Category = category;
            product.Discontinued = false;
            product.Status = Status.Yes;

            var productRepository = new Com.Andyshi.NH3.Repositories.ProductRepository();
            productRepository.Add(product);

            var p = productRepository.GetById(product.ID);

            Assert.IsNotNull(p.Category);
            Assert.AreEqual(category.Name, p.Category.Name);

        }
        [Test]
        public void find_category_and_products()
        {


            var categoryrepository = new Com.Andyshi.NH3.Repositories.CategoryRepository();
            var category = categoryrepository.First();



            Assert.IsNotNull(category);

            Assert.AreEqual(1, category.Products.Count);

        }

      
    }
}
