using Model.BUS;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductBus _productBus;
        private const string msgOk = "Ok";

        public ProductController()
        {
            _productBus = new ProductBus();
        }
        // GET: Product
        public ActionResult Index()
        {
            CategoryBus _categoryBus = new CategoryBus();
            List<Category> category = _categoryBus.findAll();
            SelectList list = new SelectList(category, "idCategory", "name");
            ViewBag.ListCategories = list;
            List<Product> productsList = _productBus.findAll();
            ViewBag.DeleteMessage = TempData["deleteMessage"];
            return View(productsList);
        }

        // GET: Product/Details/5
        public ActionResult Details(string id)
        {
            CategoryBus _categoryBus = new CategoryBus();
            Product product = _productBus.find(id);
            List<Category> category = _categoryBus.findAll();
            SelectList list = new SelectList(category, "idCategory", "name");
            ViewBag.ListCategories = list;
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            CategoryBus _categoryBus = new CategoryBus();
            List<Category> category = _categoryBus.findAll();
            SelectList list = new SelectList(category, "idCategory", "name");
            ViewBag.ListCategories = list;
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            CategoryBus _categoryBus = new CategoryBus();
            List<Category> category = _categoryBus.findAll();
            SelectList list = new SelectList(category, "idCategory", "name");
            ViewBag.ListCategories = list;

            if (ModelState.IsValid)
            {
                string msg = _productBus.create(product);
                ViewBag.Message = msg;
                if (msg.Equals(msgOk))
                {
                    ModelState.Clear();
                }

            }
            return View();
        }

        // GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
            CategoryBus _categoryBus = new CategoryBus();
            List<Category> category = _categoryBus.findAll();
            SelectList list = new SelectList(category, "idCategory", "name");

            ViewBag.ListCategories = list;
            Product product = _productBus.find(id);
            return View(product);

        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {

            CategoryBus _categoryBus = new CategoryBus();
            List<Category> data = _categoryBus.findAll();
            SelectList list = new SelectList(data, "idCategory", "name");
            ViewBag.ListCategories = list;
            
            try
            {
                string msg = _productBus.update(product);
                ViewBag.Message = msg;

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(string id)
        {
            Product product = new Product();
            product = _productBus.find(id);
            return View(product);

        }

        // POST: Product/Delete/5
        [HttpPost,  ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            try
            {

                string msg = _productBus.delete(id);
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
