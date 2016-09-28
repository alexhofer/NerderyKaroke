using System;
using System.Linq;
using System.Web.Mvc;

using AutoMapper;

using NerderyKaraoke.Core.Data.Models;
using NerderyKaraoke.Core.Extensions;
using NerderyKaraoke.Core.Services;
using NerderyKaraoke.UI.Models.SongRequest;

namespace NerderyKaraoke.UI.Controllers
{
	[Authorize(Roles = "Administrator")]
	public class SongRequestController : Controller
	{
		private readonly ISongRequestManager _songRequestManager;
		private readonly IMapper _mapper;

		private static readonly object _lock = new object();

		public SongRequestController(IMapper mapper, ISongRequestManager songRequestManager)
		{
			_songRequestManager = songRequestManager;
			if (_songRequestManager == null)
				throw new ArgumentNullException(nameof(songRequestManager));

			_mapper = mapper;
			if (_mapper == null)
				throw new ArgumentNullException(nameof(mapper));
		}

		// GET: SongRequest
		[HttpGet]
		[AllowAnonymous]
		public ActionResult Create()
		{
			return View();
		}

		// POST: SongRequest
		[HttpPost]
		[AllowAnonymous]
		public ActionResult Create(CreateViewModel songRequest)
		{
			if (!ModelState.IsValid)
				return View(songRequest);

			lock (_lock)
			{
				try
				{
					var lastSongOrder = _songRequestManager.GetAll().OrderByDescending(x => x.RequestOrder).FirstOrDefault()?.RequestOrder;
					var request = _mapper.Map<SongRequest>(songRequest);
					request.RequestOrder = lastSongOrder.GetValueOrDefault() + 1;
					_songRequestManager.Add(request);
				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
					return View(songRequest);
				}
			}

			return RedirectToAction("Index", "Home");
		}

		// GET: SongRequest/Edit/Id
		[HttpGet]
		public ActionResult Edit(Guid id)
		{
			var songRequest = _songRequestManager.Get(id);
			var model = _mapper.Map<EditViewModel>(songRequest);

			return View(model);
		}

		// POST: SongRequest/Edit
		[HttpPost]
		public ActionResult Edit(EditViewModel songRequest)
		{
			if (!ModelState.IsValid)
				return View(songRequest);

			try
			{
				var entity = _songRequestManager.Get(songRequest.Id);
				var request = entity.InjectFrom(songRequest);
				_songRequestManager.Update(request);
			}

			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
				return View(songRequest);
			}

			return RedirectToAction("Index", "Admin");
		}

		// GET: SongRequest/Delete/Id
		[HttpGet]
		public ActionResult Delete(Guid id)
		{
			var songRequest = _songRequestManager.Get(id);
			var model = _mapper.Map<DeleteViewModel>(songRequest);

			return View(model);
		}

		// POST: SongRequest/Delete
		[HttpPost]
		public ActionResult Delete(DeleteViewModel songRequest)
		{
			if (!ModelState.IsValid)
				return View(songRequest);

			try
			{
				var entity = _songRequestManager.Get(songRequest.Id);
				_songRequestManager.Delete(entity);
			}

			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
				return View(songRequest);
			}

			return RedirectToAction("Index", "Admin");

		}

		// GET: SongRequest/DeleteAll
		[HttpGet]
		public ActionResult DeleteAll()
		{
			return View();
		}

		// POST: SongRequest/DeleteAll
		[HttpPost]
		[ActionName("DeleteAll")]
		public ActionResult DeleteAllSongRequests()
		{
			try
			{
				_songRequestManager.DeleteAll();
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
				return View();
			}

			return RedirectToAction("Index", "Admin");
		}
	}

}