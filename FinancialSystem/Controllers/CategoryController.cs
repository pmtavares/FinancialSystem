using Model.BUS;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryBus _categoryBus;
        private const string msgOk = "Ok";

        public CategoryController()
        {
            _categoryBus = new CategoryBus();
        }

        // GET: Category
        public ActionResult Index()
        {
            List<Category> categories = new List<Category>();
            ViewBag.DeleteMessage = TempData["deleteMessage"];
            categories = _categoryBus.findAll();

            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(string id)
        {
            Category category = new Category();
            category = _categoryBus.find(id);
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                string msg = _categoryBus.create(category);
                ViewBag.Message = msg;
                if (msg.Equals(msgOk))
                {
                    ModelState.Clear();
                }
            }
            return View();
        }

        // GET: Category/Edit/5
        public ActionResult Edit(string id)
        {
            Category category = _categoryBus.find(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                string msg = _categoryBus.update(category);
                ViewBag.Message = msg;

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(string id)
        {
            Category category = _categoryBus.find(id);
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            try
            {
                string msg = _categoryBus.delete(id);
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
