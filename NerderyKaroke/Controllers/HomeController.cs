using NerderyKaroke.Models;
using NerderyKaroke.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerderyKaroke.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = SongRepository.SongList;
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}