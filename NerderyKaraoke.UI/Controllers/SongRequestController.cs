using System;
using System.Web.Mvc;
using AutoMapper;
using NerderyKaraoke.Core.Data.Models;
using NerderyKaraoke.Core.Services;
using NerderyKaraoke.UI.Models.Shared;

namespace NerderyKaraoke.UI.Controllers
{
  public class SongRequestController : Controller
  {
	  private readonly ISongRequestManager _songRequestManager;
	  private readonly IMapper _mapper;

		public SongRequestController(IMapper mapper, ISongRequestManager songRequestManager)
		{
			_songRequestManager = songRequestManager;
			if (_songRequestManager == null)
				throw new ArgumentNullException();

			_mapper = mapper;
			if (_mapper == null)
				throw new ArgumentNullException();
		}

	  // GET: SongRequest
		[HttpGet]
		public ActionResult Create()
    {
        return View();
    }

		// POST: SongRequest
		[HttpPost]
		public ActionResult Create(SongRequestViewModel songRequest)
		{
			if (!ModelState.IsValid)
				return View(songRequest);

			try
			{
				var request = _mapper.Map<SongRequest>(songRequest);
				_songRequestManager.Add(request);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
				return View(songRequest);
			}

			return RedirectToAction("Index", "Home");
		}

  }
}