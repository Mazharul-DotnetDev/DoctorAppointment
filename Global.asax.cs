using DoctorAppointment.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Unity.AspNet.WebApi;
using Unity;

namespace DoctorAppointment
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //GlobalConfiguration.Configure(WebApiConfig.Register);

            // Initialize Unity container
            var container = new UnityContainer();

            // Register your services and controllers here
            container.RegisterType<ITokenService, TokenService>();
            container.RegisterType<IConsumerService, ConsumerService>();

            // Set the Unity dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);


            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
