using DevShop.Infraestructure.Map;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace DevShop.Infraestructure.Context
{
    public class DevShopContext
    {
        #region Properties

        private static ISessionFactory session;

        #endregion

        #region Methods

        public static ISession AbrirSessao()
        {
            return CriarSessao().OpenSession();
        }

        #endregion

        #region Private methods

        private static ISessionFactory CriarSessao()
        {
            if (session != null)
            {
                return session;
            }

            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration
                        .MsSql2012
                        .ConnectionString("Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=DevShopBD;Data Source=(local);Initial File Name=\"\";")
                        .ShowSql()
                        .FormatSql())
                .Mappings(x =>
                    x.FluentMappings.AddFromAssemblyOf<DesenvolvedorMap>())
                //.ExposeConfiguration(x => new SchemaExport(x).Create(true, true))
                .BuildSessionFactory();
        }

        #endregion
    }
}
