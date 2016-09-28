using Autofac;
using AutoMapper;

using NerderyKaraoke.UI.Profiles;

namespace NerderyKaraoke.UI.BindingModules
{
	public class ApplicationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.Register(c => new MapperConfiguration(GenerateMapperConfiguration))
				.AsSelf()
				.SingleInstance();

			builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
				.As<IMapper>()
				.SingleInstance();
		}

		private static void GenerateMapperConfiguration(IMapperConfigurationExpression config)
		{
			config.AddProfile<ViewModelMappingProfile>();
		}
	}
}