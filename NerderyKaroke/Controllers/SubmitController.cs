using NerderyKaroke.Models;
using NerderyKaroke.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerderyKaroke.Controllers
{
    public class SubmitController : Controller
    {
        // GET: Submit
        public ActionResult Index()
        {
            return View();
        }

        // POST: Submit/Create
        [HttpPost]
        public ActionResult Create(SongModel model)
        {
            try
            {
                model.Id = JSONService.GetSongList().Count + 1;
                JSONService.AddEntry(model);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
