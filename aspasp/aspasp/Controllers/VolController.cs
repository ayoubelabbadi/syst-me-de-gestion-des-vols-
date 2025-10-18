using System;
using System.Web.Mvc;
using Aeroport.Models;
using Aeroport.Repository;

namespace Aeroport.Controllers
{
    public class VolController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VolController()
        {
            _unitOfWork = new UnitOfWork(new Aeroport.Data.AeroportDbContext());
        }

        public VolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var vols = _unitOfWork.Vols.ObtenirVolsAvecDetails();
            return View(vols);
        }

        public ActionResult Details(int id)
        {
            var vol = _unitOfWork.Vols.GetById(id);
            if (vol == null)
                return HttpNotFound();
            return View(vol);
        }

        public ActionResult Create()
        {
            ViewBag.AvionId = new SelectList(_unitOfWork.Avions.GetAll(), "Id", "Modele");
            ViewBag.PiloteId = new SelectList(_unitOfWork.Pilotes.GetAll(), "Id", "Nom"); // adapt "Nom" to your property
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vol vol)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Vols.Add(vol);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.AvionId = new SelectList(_unitOfWork.Avions.GetAll(), "Id", "Modele", vol.AvionId);
            ViewBag.PiloteId = new SelectList(_unitOfWork.Pilotes.GetAll(), "Id", "Nom", vol.PiloteId);
            return View(vol);
        }

        public ActionResult Edit(int id)
        {
            var vol = _unitOfWork.Vols.GetById(id);
            if (vol == null)
                return HttpNotFound();

            ViewBag.AvionId = new SelectList(_unitOfWork.Avions.GetAll(), "Id", "Modele", vol.AvionId);
            ViewBag.PiloteId = new SelectList(_unitOfWork.Pilotes.GetAll(), "Id", "Nom", vol.PiloteId);
            return View(vol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vol vol)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Vols.Update(vol);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.AvionId = new SelectList(_unitOfWork.Avions.GetAll(), "Id", "Modele", vol.AvionId);
            ViewBag.PiloteId = new SelectList(_unitOfWork.Pilotes.GetAll(), "Id", "Nom", vol.PiloteId);
            return View(vol);
        }

        public ActionResult Delete(int id)
        {
            var vol = _unitOfWork.Vols.GetById(id);
            if (vol == null)
                return HttpNotFound();
            return View(vol);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var vol = _unitOfWork.Vols.GetById(id);
            if (vol != null)
            {
                _unitOfWork.Vols.Remove(vol);
                _unitOfWork.Complete();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
