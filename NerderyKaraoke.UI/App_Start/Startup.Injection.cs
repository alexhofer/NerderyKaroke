using System.Reflection;
using System.Web.Mvc;

using Owin;

using Autofac;
using Autofac.Integration.Mvc;

using NerderyKaraoke.Core;
using NerderyKaraoke.UI.BindingModules;

namespace NerderyKaraoke.UI
{
	public partial class Startup
	{
		public void ConfigureInjection(IAppBuilder app)
		{
			var builder = new ContainerBuilder();

			// Controllers
			var bindAssembly = Assembly.GetExecutingAssembly();
			builder.RegisterControllers(bindAssembly);

			DependencyRegistrar.RegisterDependencies(builder,
				new RepositoryModule(),
				new ApplicationModule());

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}