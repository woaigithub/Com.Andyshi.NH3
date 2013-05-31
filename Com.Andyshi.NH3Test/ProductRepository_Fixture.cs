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

        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            this._configuration = new Configuration();
            this._configuration.Configure();
            this._configuration.AddAssembly(typeof(Com.Andyshi.NH3.Domain.Product).Assembly);
            this._sessionFactory = this._configuration.BuildSessionFactory();

        }
        [SetUp]
        public void SetupContext()
        {
            //new SchemaExport(_configuration).Execute(false, true, false);
        }







        [Test]
        public void add_new_with_category()
        {
            var category = new Com.Andyshi.NH3.Domain.Category();
            category.Name = "category1";

            var categoryrepository = new Com.Andyshi.NH3.Repositories.CategoryRepository();
            categoryrepository.Add(category);

            var product = new Com.Andyshi.NH3.Domain.Product();
            product.Name = "product1";
            product.Category = category;
            product.Discontinued = false;

            var productRepository = new Com.Andyshi.NH3.Repositories.ProductRepository();
            productRepository.Add(product);


            var p = productRepository.GetById(product.Id);

            p.Name = "safsfd";
            productRepository.Update(p);

            p.Name = "000000000";
            productRepository.Update(p);

            Assert.IsNotNull(p.Category);
            Assert.AreEqual(category.Name, p.Category.Name);

        }
        [Test]
        public void find_test()
        {
            var person = new Com.Andyshi.NH3.Domain.Product() { Name = "optimistic", Category = new Category() { Name = "cate1" }, Discontinued = false };
            using (var session = this._sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(person);

                    tx.Commit();
                }
            }

            using (var session = this._sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
               
                    session.Save(person);
                }
            }
        }
    }
}
