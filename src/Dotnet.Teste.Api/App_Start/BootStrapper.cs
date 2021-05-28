using Dotnet.Teste.Core.Infra;
using Dotnet.Teste.Core.Repository;
using Dotnet.Teste.Core.Service;
using Dotnet.Teste.Core.Util;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace Dotnet.Teste.Api.App_Start
{
    public class BootStrapper
    {
        public static void Init()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.RegisterSingleton<IOperationRepository, OperationRepository>();
            container.Register<IOperationService, OperationService>();
            container.Register<IFileData, FileData>();
            container.Register<RandomGenerator>();
            container.Register<OperationFactory>();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
       new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}