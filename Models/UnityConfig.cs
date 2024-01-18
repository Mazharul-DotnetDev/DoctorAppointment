using DoctorAppointment.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

namespace DoctorAppointment.Models
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register your services and controllers here
            container.RegisterType<ITokenService, TokenService>();
            container.RegisterType<IConsumerService, ConsumerService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}