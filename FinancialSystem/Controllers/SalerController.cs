using Model.BUS;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers
{
    public class SalerController : Controller
    {

        private readonly SalerBus _salerBus;
        // GET: Saler
        public ActionResult Index()
        {
            List<Saler> salers = new List<Saler>();
            salers = _salerBus.findAll();
            return View(salers);
        }

        // GET: Saler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Saler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Saler/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Saler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Saler/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Saler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Saler/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
