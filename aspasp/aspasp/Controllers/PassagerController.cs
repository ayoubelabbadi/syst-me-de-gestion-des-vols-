using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Aeroport.Models;
using Aeroport.Repository;
using Aeroport.Data;

namespace Aeroport.Controllers
{
    public class PassagerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PassagerController() : this(new UnitOfWork(new AeroportDbContext()))
        {
        }

        public PassagerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var passagers = _unitOfWork.Passagers.GetAll().ToList();
            return View(passagers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var passager = _unitOfWork.Passagers.GetById(id.Value);
            if (passager == null) return HttpNotFound();

            return View(passager);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Passager passager)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Passagers.Add(passager);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(passager);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var passager = _unitOfWork.Passagers.GetById(id.Value);
            if (passager == null) return HttpNotFound();

            return View(passager);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Passager passager)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Passagers.Update(passager);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(passager);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var passager = _unitOfWork.Passagers.GetById(id.Value);
            if (passager == null) return HttpNotFound();

            return View(passager);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var passager = _unitOfWork.Passagers.GetById(id);
            if (passager != null)
            {
                _unitOfWork.Passagers.Remove(passager);
                _unitOfWork.Complete();
            }
            return RedirectToAction("Index");
        }
    }
}
