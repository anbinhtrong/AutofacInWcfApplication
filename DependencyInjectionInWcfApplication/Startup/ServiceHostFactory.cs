using System;
using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;

namespace DependencyInjectionInWcfApplication.Startup
{
    public class ServiceHostFactory : AutofacHostFactory
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MessageService>().As<IMessageService>();
            builder.RegisterType<Service1>();
            Container = builder.Build();

            return base.CreateServiceHost(constructorString, baseAddresses);
        }

        protected override ServiceHost CreateSingletonServiceHost(object singletonInstance, Uri[] baseAddresses)
        {
            if (singletonInstance == null)
            {
                throw new ArgumentNullException("singletonInstance");
            }
            if (baseAddresses == null)
            {
                throw new ArgumentNullException("baseAddresses");
            }
            return new ServiceHost(singletonInstance, baseAddresses);
        }
    }
}