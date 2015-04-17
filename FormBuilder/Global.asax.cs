using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FormBuilder.Data;
using WebMatrix.WebData;

namespace FormBuilder
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        
        }
    }


    public class SimpleMembershipInitializer
    {
        public SimpleMembershipInitializer()
        {
            //Database.SetInitializer<FormBuilderContext>(null);
            Database.SetInitializer(
            new MigrateDatabaseToLatestVersion<FormBuilderContext, FormBuilderMigrationsConfiguration>());

            var connectionStringName = "";

            if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
            {
                connectionStringName = ConfigurationManager.AppSettings["ConnectionStringName"];
            }
            else
            {
                connectionStringName = "FormBuilderDev";
            }
                
            try
            {
                using (var context = new FormBuilderContext())
                {
                    if (!context.Database.Exists())
                    {
                        // Create the SimpleMembership database without Entity Framework migration schema
                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }
                }

                WebSecurity.InitializeDatabaseConnection(connectionStringName, "Users", "Id", "UserName", autoCreateTables: true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }

        
}