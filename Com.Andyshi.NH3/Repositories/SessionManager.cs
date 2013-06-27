using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Tool.hbm2ddl;

namespace Com.Andyshi.NH3.Repositories
{
    public class SessionManager
    {
        private static NHibernate.ISessionFactory _sessionFactory;
        public static SessionManager Instance { get; private set; }


        static SessionManager()
        {
            var manager = new SessionManager();
            manager.initialize();
            Instance = manager;
        }

        private void initialize()
        {
            if (_sessionFactory == null)
            {

                #region
                //文件位置不同，代码不同
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

                //破解版
                //HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();

                //正式版
                HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
                #endregion
                var configuration = new NHibernate.Cfg.Configuration();
                configuration.Configure();

                configuration.AddAssembly(typeof(Domain.Product).Assembly);


                _sessionFactory = configuration.BuildSessionFactory();



            }
        }
        private SessionManager()
        { }

        public NHibernate.ISession CreateSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
