using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BUS
{
    public class ProductBus
    {
        private readonly ProductDao _productDao;

        public ProductBus()
        {
            _productDao = new ProductDao();
        }

        public string create(Product saler)
        {
            //Validation
                       
            _productDao.create(saler);

            //Message Category
            return "Created";
        }

        public string update(Product product)
        {
            //Validation



            _productDao.update(product);

            //Message Category
            return "Updated";
        }

        public Product find(string id)
        {
            //Validation



            Product product = _productDao.find(id);

            //Message Category
            return product;
        }

        public List<Product> findAll()
        {
            //Validation



            List<Product> products = _productDao.findAll();

            //Message Category
            return products;
        }

        public string delete(string id)
        {
            Product product = _productDao.find(id);

            if (product == null)
            {
                return "product does not exist";
            }


            return _productDao.delete(product);
        }

        public List<Product> findAll(string name, string code, string pps)
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
                return _productDao.findAll();
            }
            return _productDao.findAll();
        }
    }
}
