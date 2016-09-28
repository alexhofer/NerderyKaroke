using System;
using System.Collections.Generic;
using System.Web.Mvc;

using AutoMapper;

using NerderyKaraoke.Core.Services;
using NerderyKaraoke.UI.Extensions;
using NerderyKaraoke.UI.Models.SongRequest;

namespace NerderyKaraoke.UI.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		private readonly ISongRequestManager _songRequestManager;
		private readonly IMapper _mapper;

		public HomeController(ISongRequestManager songRequestManager, IMapper mapper)
		{
			_songRequestManager = songRequestManager;
			if (_songRequestManager == null)
				throw new ArgumentNullException(nameof(songRequestManager));

			_mapper = mapper;
			if (_mapper == null)
				throw new ArgumentNullException(nameof(mapper));
		}

		public ActionResult Index()
		{
			var songRequests = _songRequestManager.GetAll().FairOrder();
			var model = _mapper.Map<IEnumerable<CreateViewModel>>(songRequests);

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