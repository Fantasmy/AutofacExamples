using Autofac;
using Autofac.Configuration;
using AutoService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceXml
{
    class Program
    {
        public static IContainer Container { get; private set; }

        static void Main(string[] args)
        {
            RegisterComponents();
            Resolution();
            Console.ReadLine();
        }
        private static void RegisterComponents()
        {
            var config = new ConfigurationBuilder();
            config.AddXmlFile("autofac.xml");

            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            Container = builder.Build();
        }

        public static void Resolution()
        {
            using (var scope = Container.BeginLifetimeScope()) //genera scope del contenedor
            {
                var bmw = scope.Resolve<BmwAutoService>();  // resuelve todas las dependencias
                var honda = scope.Resolve<HondaAutoService>(); // como no tiene atributos no se pasa nada
                var ford = scope.Resolve<FordAutoService>();

                AutoServiceCallerImp serviceCaller = new AutoServiceCallerImp(bmw, honda, ford); // se pasan lso 3 parámetros
                serviceCaller.callAutoService();
            }
        }

    }
}