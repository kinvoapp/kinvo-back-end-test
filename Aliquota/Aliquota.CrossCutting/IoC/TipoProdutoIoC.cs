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
    public static class TipoProdutoIoC
    {
        public static void Registar(IUnityContainer container)
        {
            Registar(container, delegate { return new TransientLifetimeManager(); });
        }

        public static void Registar(IUnityContainer container, Func<ITypeLifetimeManager> newLifetime)
        {
            container.RegisterType<ITipoProdutoRepositorio, TipoProdutoRepositorio>(newLifetime(),
                    new Interceptor<InterfaceInterceptor>());

            container.RegisterType<ITipoProdutoBusiness, TipoProdutoBusiness>(newLifetime(),
                    new Interceptor<InterfaceInterceptor>(),
                    new Interceptor<InterfaceInterceptor>());

        }
    }
}
