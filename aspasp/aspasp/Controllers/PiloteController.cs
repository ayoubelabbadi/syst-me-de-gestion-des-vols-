using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Aeroport.Models;
using Aeroport.Repository;
using Aeroport.Data;  

namespace Aeroport.Controllers
{
    public class PiloteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PiloteController()
        {
            _unitOfWork = new UnitOfWork(new AeroportDbContext());
        }

        public PiloteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var pilotes = _unitOfWork.Pilotes.GetAll().ToList();
            return View(pilotes);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pilote = _unitOfWork.Pilotes.GetById(id.Value);
            if (pilote == null) return HttpNotFound();

            return View(pilote);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pilote pilote)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Pilotes.Add(pilote);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erreur lors de l'ajout : " + ex.Message);
                }
            }
            return View(pilote);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pilote = _unitOfWork.Pilotes.GetById(id.Value);
            if (pilote == null) return HttpNotFound();

            return View(pilote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pilote pilote)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Pilotes.Update(pilote);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erreur lors de la modification : " + ex.Message);
                }
            }
            return View(pilote);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pilote = _unitOfWork.Pilotes.GetById(id.Value);
            if (pilote == null) return HttpNotFound();

            return View(pilote);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var pilote = _unitOfWork.Pilotes.GetById(id);
                if (pilote != null)
                {
                    _unitOfWork.Pilotes.Remove(pilote);
                    _unitOfWork.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erreur lors de la suppression : " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
