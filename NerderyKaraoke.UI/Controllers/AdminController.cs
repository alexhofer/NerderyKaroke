using System;
using System.Collections.Generic;
using System.Web.Mvc;

using AutoMapper;

using NerderyKaraoke.Core.Services;
using NerderyKaraoke.UI.Extensions;
using NerderyKaraoke.UI.Models.SongRequest;

namespace NerderyKaraoke.UI.Controllers
{
	[Authorize(Roles = "Administrator")]
	public class AdminController : Controller
	{
		private readonly ISongRequestManager _songRequestManager;
		private readonly IMapper _mapper;

		public AdminController(ISongRequestManager songRequestManager, IMapper mapper)
		{
			_songRequestManager = songRequestManager;
			if (_songRequestManager == null)
				throw new ArgumentNullException(nameof(songRequestManager));

			_mapper = mapper;
			if (_mapper == null)
				throw new ArgumentNullException(nameof(mapper));
		}

		// GET: Admin
		public ActionResult Index()
		{
			var songRequests = _songRequestManager.GetAll().FairOrder();
			var model = _mapper.Map<IEnumerable<EditViewModel>>(songRequests);
			return View(model);
		}
	}
}