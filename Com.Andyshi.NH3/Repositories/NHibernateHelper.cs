using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Tool.hbm2ddl;

namespace Com.Andyshi.NH3.Repositories
{
    public class NHibernateHelper
    {
        private static NHibernate.ISessionFactory _sessionFactory;

        public static NHibernate.ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new NHibernate.Cfg.Configuration();
                    configuration.Configure();

                    configuration.AddAssembly(typeof(Domain.Product).Assembly);
                   
                   
                    _sessionFactory = configuration.BuildSessionFactory();



                }
                return _sessionFactory;
            }
        }

        static NHibernateHelper()
        {

        }

        public static NHibernate.ISession CreateSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
