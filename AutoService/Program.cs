using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
    class Program
    {
        public static IContainer Container { get; private set; }

        private static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BmwAutoService>().SingleInstance();  // para este ejemplo vale SingleInstance. Si hay que llamar más veces se cambiaria
            builder.RegisterType<HondaAutoService>().SingleInstance(); // sino sería por request
            builder.RegisterType<FordAutoService>().SingleInstance();
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
