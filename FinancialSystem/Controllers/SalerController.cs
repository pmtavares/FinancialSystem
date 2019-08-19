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
        private const string msgOk = "Ok";

        public SalerController()
        {
            _salerBus = new SalerBus();
        }

        // GET: Saler
        public ActionResult Index()
        {
            List<Saler> salers = _salerBus.findAll();
            ViewBag.DeleteMessage = TempData["deleteMessage"];
            return View(salers);
        }

        [HttpPost]
        public ActionResult Index(string txtname, string txtcode, string txtpps)
        {
            List<Saler> clients = _salerBus.findAll(txtname, txtcode, txtpps);

            return View(clients);
        }

        // GET: Saler/Details/5
        public ActionResult Details(string id)
        {
            Saler saler = _salerBus.find(id);
    
            return View(saler);
        }

        // GET: Saler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Saler/Create
        [HttpPost]
        public ActionResult Create(Saler saler)
        {
            if (ModelState.IsValid)
            {
                string msg = _salerBus.create(saler);
                ViewBag.Message = msg;
                if (msg.Equals(msgOk))
                {
                    ModelState.Clear();
                }

            }
            return View();
        }

        // GET: Saler/Edit/5
        public ActionResult Edit(string id)
        {
            Saler saler = _salerBus.find(id);
            return View(saler);
        }

        // POST: Saler/Edit/5
        [HttpPost]
        public ActionResult Edit(Saler saler)
        {
            try
            {
                string msg = _salerBus.update(saler);
                ViewBag.Message = msg;

                return View();

            }
            catch
            {
                return View();
            
            }
        }

        // GET: Saler/Delete/5
        public ActionResult Delete(string id)
        {
            Saler saler = _salerBus.find(id);
            return View(saler);
        }

        // POST: Saler/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            try
            {
                string msg = _salerBus.delete(id);
                TempData["deleteMessage"] = msg;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
