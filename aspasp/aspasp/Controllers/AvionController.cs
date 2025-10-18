using System;
using System.Web.Mvc;
using Aeroport.Repository;
using aspasp.Models;
using aspasp.Models;

namespace aspasp.Controllers  
{
    public class AvionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AvionController()
        {
            _unitOfWork = new UnitOfWork(new Aeroport.Data.AeroportDbContext());
        }

        public AvionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var avions = _unitOfWork.Avions.GetAll();
            return View(avions);
        }

        public ActionResult Details(int id)
        {
            var avion = _unitOfWork.Avions.GetById(id);
            if (avion == null)
            {
                return HttpNotFound();
            }
            return View(avion);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Avion avion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Avions.Add(avion);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Une erreur s'est produite lors de l'ajout: " + ex.Message);
            }
            return View(avion);
        }

        public ActionResult Edit(int id)
        {
            var avion = _unitOfWork.Avions.GetById(id);
            if (avion == null)
            {
                return HttpNotFound();
            }
            return View(avion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Avion avion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Avions.Update(avion);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Une erreur s'est produite lors de la modification: " + ex.Message);
            }
            return View(avion);
        }

        public ActionResult Delete(int id)
        {
            var avion = _unitOfWork.Avions.GetById(id);
            if (avion == null)
            {
                return HttpNotFound();
            }
            return View(avion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var avion = _unitOfWork.Avions.GetById(id);
                if (avion != null)
                {
                    _unitOfWork.Avions.Remove(avion);
                    _unitOfWork.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erreur lors de la suppression: " + ex.Message;
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
