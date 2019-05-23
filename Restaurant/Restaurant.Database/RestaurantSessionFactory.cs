using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace Restaurant.Database
{
    public interface IRestaurantSessionFactory
    {
        ISessionFactory CreateSessionFactory();
        ISession Session { get; set; }
    }
    public class RestaurantSessionFactory : IRestaurantSessionFactory
    {
        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                  .ConnectionString(@"Server=tcp:wywrot.database.windows.net,1433;Initial Catalog=Restaurant;Persist Security Info=False;User ID=RafalAdmin;Password=bazaRafalKinga1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
                              .ShowSql()
                )
               .ExposeConfiguration(cfg => cfg.AddDeserializedMapping(MappingHelper.GetIdentityMappings(new[] { typeof(ApplicationUser) }), null))
               .Mappings(m =>
                          m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
        public ISession Session
        {
            get {
                return CreateSessionFactory().OpenSession();
            }
            set
            {
                Session = value;
            }
        }
    }
}
