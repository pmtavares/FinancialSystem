using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BUS
{
    public class SalerBus
    {
        private readonly SalerDao _salerDao;

        public SalerBus()
        {
            _salerDao = new SalerDao();
        }
        public string create(Saler saler)
        {
            //Validation



            _salerDao.createSP(saler);

            //Message Category
            return "Created";
        }

        public string update(Saler saler)
        {
            //Validation



            _salerDao.update(saler);

            //Message Category
            return "Updated";
        }

        public Saler find(string id)
        {
            //Validation



            Saler category = _salerDao.find(id);

            //Message Category
            return category;
        }

        public List<Saler> findAll()
        {
            //Validation



            List<Saler> salers = _salerDao.findAll();

            //Message Category
            return salers;
        }

        public string delete(string id)
        {
            Saler saler = _salerDao.find(id);

            if (saler == null)
            {
                return "Saler does not exist";
            }


            return _salerDao.delete(saler);
        }

        public List<Saler> findAll(string name, string code, string pps)
        {

            if (code == "" || code == null)
            {
                code = "NULL";
            }

            if (pps == "" || pps == null)
            {
                pps = "NULL";
            }
            if (name == "" || name == null)

                name = "NULL";

            if (name == null && (pps == null && code == null))
            {
                return _salerDao.findAll();
            }
            return _salerDao.findAllSaler(name, code, pps);
        }
    }
}
