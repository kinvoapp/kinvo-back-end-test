using Aliquota.Applications.Modules;
using Aliquota.Domain.AplicacaoModule;
using Aliquota.Domain.ProdutoModule;
using Aliquota.Domain.Shared;
using Aliquota.Forms.Modules.Aplicacoes;
using Aliquota.Forms.Modules.Produtos;
using Aliquota.Infrastructure;
using Aliquota.Infrastructure.Modules;
using Autofac;

namespace Aliquota.Forms.Shared
{
    public class AutoFac
    {
        private static ContainerBuilder Builder = new();
        public static IContainer Container;

        static AutoFac()
        {
            Builder.RegisterType<AliquotaDBContext>().InstancePerLifetimeScope();
            ConfigureORM();
            ConfigureAppService();
            ConfigureOperations();
            Container = Builder.Build();
        }

        private static void ConfigureOperations()
        {
            Builder.RegisterType<ProdutoOperacoes>().InstancePerDependency();
            Builder.RegisterType<AplicacaoOperacoes>().InstancePerDependency();
        }

        private static void ConfigureAppService()
        {
            Builder.RegisterType<ProdutoApplication>().InstancePerDependency();
            Builder.RegisterType<AplicacaoApplication>().InstancePerDependency();
        }

        private static void ConfigureORM()
        {
            Builder.RegisterType<ProdutoORM>().As<IRepository<Produto>>().InstancePerDependency();
            Builder.RegisterType<AplicacaoORM>().As<IRepository<Aplicacao>>().InstancePerDependency();
        }
    }
}
