using NerderyKaroke.Models;
using NerderyKaroke.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerderyKaroke.Controllers
{
    public class SuperSecretAdminController : Controller
    {
        // GET: SuperSecretAdmin
        public ActionResult Index()
        {
            var model = JSONService.GetSongList();
            return View(model);
        }

        // GET: SuperSecretAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            var model = JSONService.GetSongList().Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        // POST: SuperSecretAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Song edited)
        {
            try
            {
                JSONService.UpdateEntry(id, edited);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperSecretAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            var model = JSONService.GetSongList().Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        // POST: SuperSecretAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Song toBeDeleted)
        {
            try
            {
                JSONService.DeleteEntry(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteAll()
        {
            JSONService.DeleteAll();
            return RedirectToAction("Index");
        }
    }
}
