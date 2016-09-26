using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace NerderyKaraoke.Core
{
	public static class DependencyRegistrar
	{
		public static ContainerBuilder RegisterDependencies(params Module[] modules)
		{
			var builder = new ContainerBuilder();

			RegisterDependencies(builder, modules);

			return builder;
		}

		public static void RegisterDependencies(ContainerBuilder builder, params Module[] modules)
		{
			foreach (var module in modules)
			{
				builder.RegisterModule(module);
			}
		}
	}
}
