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
            var model = SongRepository.SongList;
            return View(model);
        }

        // GET: SuperSecretAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            var model = SongRepository.SongList.Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        // POST: SuperSecretAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SongModel editedModel)
        {
            try
            {
                var model = SongRepository.SongList.Where(x => x.Id == id).FirstOrDefault();
                if (model != null)
                {
                    model.SingerName = editedModel.SingerName;
                    model.SongTitle = editedModel.SongTitle;
                }

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
            var model = SongRepository.SongList.Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        // POST: SuperSecretAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SongModel toBeDeleted)
        {
            try
            {
                var itemToRemove = SongRepository.SongList.Single(x => x.Id == id);
                SongRepository.SongList.Remove(itemToRemove);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteAll()
        {
            SongRepository.SongList.Clear();
            return RedirectToAction("Index");
        }
    }
}
