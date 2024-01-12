using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateDemoApp
{
    public class SessionHelper
    {



        public static ISession CreateSession()
        {

            var _connectionString = "Server=DESKTOP-O2KROQH\\SQLEXPRESS;Database=NHibernateDemoDB;Integrated Security=SSPI;TrustServerCertificate=True;";

            var mapper = new ModelMapper();
            //list all types of mappings from assembly
            mapper.AddMappings(typeof(Student).Assembly.ExportedTypes);
            //compile class mapping
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            //allow the appliaction to specify properties and mapping document
            // to be used when creating

            var hbConfig = new Configuration();

            //settings from app to nhibernate

            hbConfig.DataBaseIntegration(
                c =>
                {
                    // strategy to interact with provider
                    c.Driver<MicrosoftDataSqlClientDriver>();
                    //dialect nHibernate to build syntax to rdbms

                    c.Dialect<MsSql2012Dialect>();

                    // set connection string
                    c.ConnectionString = _connectionString;

                    // log sql statement to console
                    c.LogSqlInConsole = true;

                    //formatted logged sql statement
                    c.LogFormattedSql = true;


                }
                );

            // add mapping to NHibernate Configuration
            hbConfig.AddMapping(domainMapping);

            //Instantiate a Session Factory(Use properties, settings and mappings)

            var sessionFactory = hbConfig.BuildSessionFactory();

            var session = sessionFactory.OpenSession();

            return session;
        }

    }
}
