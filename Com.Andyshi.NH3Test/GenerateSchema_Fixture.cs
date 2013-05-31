using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate.Cfg;
using Com.Andyshi.NH3.Domain;
using NHibernate.Tool.hbm2ddl;

namespace FirstSolution.Test
{
    [TestFixture]
    public class GenerateSchema_Fixture
    {

        [Test]
        public void Can_generate_schema()
        {

            var cfg = new Configuration();

            cfg.Configure();

            cfg.AddAssembly(typeof(Product).Assembly);



            new SchemaExport(cfg).Execute(false, true, false);

        }

    }
}
