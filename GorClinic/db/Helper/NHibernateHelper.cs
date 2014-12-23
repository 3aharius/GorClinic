using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GorClinic.Helper
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private const string _ASSEMBLY = "GorClinic";

        public static string DefaultConnectionString
        {

            get
            {
                var _cfg = new Configuration();
                _cfg.Configure();
                return _cfg.GetProperty(NHibernate.Cfg.Environment.ConnectionString);
            }
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var config = new Configuration();
                    config.Configure();
                    _sessionFactory = config.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            try
            {
                var session = SessionFactory.OpenSession();
                return session;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}