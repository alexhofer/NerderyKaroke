using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;

using NerderyKaraoke.Core.Services;
using NerderyKaraoke.UI.Models.Shared;

namespace NerderyKaraoke.UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ISongRequestManager _songRequestManager;
		private readonly IMapper _mapper;

		public HomeController(ISongRequestManager songRequestManager, IMapper mapper)
		{
			_songRequestManager = songRequestManager;
			if (_songRequestManager == null)
				throw new ArgumentNullException();

			_mapper = mapper;
			if (_mapper == null)
				throw new ArgumentNullException();
		}

		public ActionResult Index()
		{
			var data = _songRequestManager.Get();
			var model = _mapper.Map<IEnumerable<SongRequestViewModel>>(data);

			return View(model);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}