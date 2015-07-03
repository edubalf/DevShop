using DevShop.Domain.Contracts.Services;
using DevShop.Startup;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            DependencyResolver.Resolver(container);


        }
    }
}
