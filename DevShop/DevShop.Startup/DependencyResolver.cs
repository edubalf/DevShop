using DevShop.Domain.Contracts.Repositories;
using DevShop.Domain.Contracts.Services;
using DevShop.Infraestructure.Context;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Startup
{
    public class DependencyResolver
    {
        public static void Resolver(UnityContainer container)
        {
            container.RegisterType<DevShopContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IDesenvolvedorService>(new HierarchicalLifetimeManager());
            container.RegisterType<IDesenvolvedorRepository>(new HierarchicalLifetimeManager());
        }
    }
}
