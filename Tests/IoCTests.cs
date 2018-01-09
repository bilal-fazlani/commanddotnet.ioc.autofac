using System;
using Autofac;
using CommandDotNet;
using CommandDotNet.IoC.Autofac;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        public class IoCTests
        {
            [Fact]
            public void CanAutofacInjectService()
            {
                ContainerBuilder containerBuilder = new ContainerBuilder();
    
                containerBuilder.RegisterType<Service>().As<IService>();
    
                IContainer container = containerBuilder.Build();
    
                AppRunner<ServiceApp> serviceApp = new AppRunner<ServiceApp>().UseAutofac(container);
                
                serviceApp.Run("Process").Should().Be(4);
            }
        }
    
        public class ServiceApp
        {
            public IService Service { get; set; }

            public int Process()
            {
                return Service?.value ?? throw new Exception("Service is not injected");
            }
        }

        public interface IService
        {
            int value { get; set; }
        }

        public class Service : IService
        {
            public int value { get; set; } = 4;
        }
    }
}