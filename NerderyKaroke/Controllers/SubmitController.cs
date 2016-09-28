using System.Web.Mvc;

using NerderyKaroke.Models;
using NerderyKaroke.Repository;

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
        public ActionResult Create(Song model)
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
