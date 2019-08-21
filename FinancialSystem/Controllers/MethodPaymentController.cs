using Model.BUS;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers
{
    public class MethodPaymentController : Controller
    {

        private readonly MethodPaymentBus _methodBus;
        private const string msgOk = "Ok";

        public MethodPaymentController()
        {
            _methodBus = new MethodPaymentBus();
        }

        // GET: MethodPayment
        public ActionResult Index()
        {
            List<MethodPayment> methods = _methodBus.findAll();
            ViewBag.DeleteMessage = TempData["deleteMessage"];
            return View(methods);
        }

        // GET: MethodPayment/Details/5
        public ActionResult Details(int id)
        {
            MethodPayment method = _methodBus.find(id);
            return View(method);
        }

        // GET: MethodPayment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MethodPayment/Create
        [HttpPost]
        public ActionResult Create(MethodPayment method)
        {
            if (ModelState.IsValid)
            {
                string msg = _methodBus.create(method);
                ViewBag.Message = msg;
                if (msg.Equals(msgOk))
                {
                    ModelState.Clear();
                }
            }
            return View();
        }

        // GET: MethodPayment/Edit/5
        public ActionResult Edit(int id)
        {
            MethodPayment method = _methodBus.find(id);
            return View(method);
        }

        // POST: MethodPayment/Edit/5
        [HttpPost]
        public ActionResult Edit(MethodPayment method)
        {
            try
            {
                string msg = _methodBus.update(method);
                ViewBag.Message = msg;

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: MethodPayment/Delete/5
        public ActionResult Delete(int id)
        {
            MethodPayment method = _methodBus.find(id);
            return View(method);
        }

        // POST: MethodPayment/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                string msg = _methodBus.delete(id);
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
