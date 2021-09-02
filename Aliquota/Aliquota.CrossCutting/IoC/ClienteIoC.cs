using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Business.Implementacao.Business;
using Aliquota.Domain.Repository.Implementacao.Repositorios;
using Aliquota.Domain.Repository.IRepositorios;
using System;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Lifetime;

namespace Aliquota.CrossCutting.IoC
{
    public static class ClienteIoC
    {
        public static void Registar(IUnityContainer container)
        {
            Registar(container, delegate { return new TransientLifetimeManager(); });
        }

        public static void Registar(IUnityContainer container, Func<ITypeLifetimeManager> newLifetime)
        {
            container.RegisterType<IClienteRepositorio, ClienteRepositorio>(newLifetime(),
                    new Interceptor<InterfaceInterceptor>());

            container.RegisterType<IClienteBusiness, ClienteBusiness>(newLifetime(),
                    new Interceptor<InterfaceInterceptor>(),
                    new Interceptor<InterfaceInterceptor>());

        }
    }
}
