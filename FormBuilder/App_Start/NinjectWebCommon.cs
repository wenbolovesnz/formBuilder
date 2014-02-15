using FormBuilder.Data.Data_Repositories;

[assembly: WebActivator.PreApplicationStartMethod(typeof(FormBuilder.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(FormBuilder.App_Start.NinjectWebCommon), "Stop")]

namespace FormBuilder.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using FormBuilder.Data;
    using System.Web.Http;
    using WebApiContrib.IoC.Ninject;
    using FormBuilder.Data.Contracts;
    using FormBuilder.Business.Entities;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);

            //Add support for Ninject & WebApi to work together
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<FormBuilderContext>().To<FormBuilderContext>().InRequestScope();
            kernel.Bind<IApplicationUnit>().To<ApplicationUnit>().InRequestScope();
            kernel.Bind<IGenericRepository<User>>().To<GenericRepository<User>>().InRequestScope();
            kernel.Bind<IGenericRepository<Role>>().To<GenericRepository<Role>>().InRequestScope();
            kernel.Bind<IGenericRepository<FormDefinitionSet>>().To<GenericRepository<FormDefinitionSet>>().InRequestScope();
            kernel.Bind<IGenericRepository<FormDefinition>>().To<GenericRepository<FormDefinition>>().InRequestScope();
            kernel.Bind<IGenericRepository<Question>>().To<GenericRepository<Question>>().InRequestScope();
            kernel.Bind<IGenericRepository<Organization>>().To<GenericRepository<Organization>>().InRequestScope();
        }        
    }
}
