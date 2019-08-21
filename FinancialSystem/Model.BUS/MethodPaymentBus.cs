using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BUS
{
    public class MethodPaymentBus
    {
        private readonly MethodPaymentDao _methodPaymentDao;

        public MethodPaymentBus()
        {
            _methodPaymentDao = new MethodPaymentDao();
        }

        public string create(MethodPayment method)
        {
            //Validation



            _methodPaymentDao.Create(method);

            //Message Category
            return "Created";
        }

        public string update(MethodPayment method)
        {
            //Validation



            _methodPaymentDao.update(method);

            //Message Category
            return "Updated";
        }

        public MethodPayment find(int id)
        {
            //Validation



            MethodPayment method = _methodPaymentDao.find(id);

            //Message Category
            return method;
        }

        public List<MethodPayment> findAll()
        {
            //Validation



            List<MethodPayment> methods = _methodPaymentDao.findAll();

            //Message Category
            return methods;
        }

        public string delete(int id)
        {
            MethodPayment method = new MethodPayment();


            method = _methodPaymentDao.find(id);
            if (method == null)
            {
                return "Category does not exist";
            }


            return _methodPaymentDao.delete(method);
        }
    }
}
