﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NerderyKaraoke.UI.Startup))]
namespace NerderyKaraoke.UI
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureInjection(app);
		}
	}
}

