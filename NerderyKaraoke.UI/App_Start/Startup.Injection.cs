using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NerderyKaraoke.Core;
using NerderyKaraoke.UI.BindingModules;
using Owin;

namespace NerderyKaraoke.UI
{
	public partial class Startup
	{
		public void ConfigureInjection(IAppBuilder app)
		{
			var builder = new ContainerBuilder();

			// Controllers
			builder.RegisterControllers(typeof (MvcApplication).Assembly);

			DependencyRegistrar.RegisterDependencies(builder,
				new RepositoryModule(),
				new ApplicationModule());

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}