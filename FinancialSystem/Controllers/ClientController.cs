using Model.BUS;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers
{
    public class ClientController : Controller
    {
        private ClientBus _clientBus;
        private const string msgOk = "Ok";

        public ClientController()
        {
            _clientBus = new ClientBus();
        }

        // GET: Client
        public ActionResult Index()
        {
            List<Client> clients = new List<Client>();
            clients = _clientBus.findAll();

            ViewBag.DeleteMessage = TempData["deleteMessage"];
            return View(clients);
        }

        [HttpPost]
        public ActionResult Index(string txtname, string txtclient, string txtpps)
        {
            List<Client> clients = new List<Client>();
            clients = _clientBus.findAllClients(txtname, txtclient ,txtpps);
            return View(clients);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            Client client = _clientBus.find(id);
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            if(ModelState.IsValid)
            {
                string msg = _clientBus.create(client);
                ViewBag.Message = msg;
                if (msg.Equals(msgOk))
                {
                    ModelState.Clear();
                }         

            }
            return View();
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            Client client = _clientBus.find(id);

            return View(client);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(Client client)
        {
            try
            {
                string msg = _clientBus.update(client);
                ViewBag.Message = msg;
                
                return View();

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            Client client = _clientBus.find(id);
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            
            try
            {
                //_clientBus.delete(id);
                string msg = _clientBus.delete(id);
                TempData["deleteMessage"]  = msg;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
