using System.Web.Http;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.Services;
using Microsoft.Practices.Unity.Configuration;
using Unity;
using Unity.WebApi;

namespace MasyvaiPrasidedaVienetu
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            container.LoadConfiguration();
            // it is NOT necessary to register your controllers

            //container.RegisterType<IUserService, UserService>();
            //container.RegisterType<ISessionService, SessionService>();
            
            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}