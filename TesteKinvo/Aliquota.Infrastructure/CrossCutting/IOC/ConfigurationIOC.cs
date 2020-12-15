using Aliquota.Application;
using Aliquota.Application.Intefaces;
using Aliquota.Application.Mapper;
using Aliquota.Domain.Core.Interfaces.Repositorys;
using Aliquota.Domain.Core.Interfaces.Services;
using Aliquota.Domain.Services;
using Aliquota.Infrastructure.Data.Repositorys;
using Autofac;

namespace Aliquota.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC
            builder.RegisterType<ApplicationServiceCliente>().As<IApplicationServiceClient>();
            builder.RegisterType<ApplicationServiceProduct>().As<IApplicationServiceProduct>();
            builder.RegisterType<ApplicationServiceFinancialApplication>().As<IApplicationServiceFinancialApplication>();
            builder.RegisterType<ServiceClient>().As<IServiceClient>();
            builder.RegisterType<ServiceProduct>().As<IServiceProduct>();
            builder.RegisterType<ServiceFinancialApplication>().As<IServiceFinancialApplication>();
            builder.RegisterType<RepositoryClient>().As<IRepositoryClient>();
            builder.RegisterType<RepositoryProduct>().As<IRepositoryProduct>();
            builder.RegisterType<RepositoryFinancialApplication>().As<IRepositoryFinancialApplication>();
            builder.RegisterType<MapperClient>().As<IMapperClient>();
            builder.RegisterType<MapperProduct>().As<IMapperProduct>();
            builder.RegisterType<MapperFinancialApplication>().As<IMapperFinancialApplication>();
            #endregion
        }
    }
}
