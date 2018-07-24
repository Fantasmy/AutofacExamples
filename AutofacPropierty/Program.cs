using Autofac;
using AutoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacPropierty
{
    class Program
    {
        public static IContainer Container { get; private set; }

        private static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BmwAutoService>().PropertiesAutowired();
            builder.RegisterType<HondaAutoService>().PropertiesAutowired();
            builder.RegisterType<FordAutoService>().PropertiesAutowired();
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
        static void Main(string[] args)
        {
            RegisterComponents();
            Resolution();
            Console.ReadLine();
        }
    }
}
