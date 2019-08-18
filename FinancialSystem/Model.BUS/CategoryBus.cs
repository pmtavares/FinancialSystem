using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BUS
{
    public class CategoryBus
    {

        private readonly CategoryDao _categoryDao;

        public CategoryBus()
        { 
            _categoryDao = new CategoryDao();
        }

        public string create(Category category)
        {
            //Validation


            
            _categoryDao.CreateSP(category);

            //Message Category
            return "Created";
        }

        public string update(Category category)
        {
            //Validation



            _categoryDao.update(category);

            //Message Category
            return "Updated";
        }

        public Category find(string id)
        {
            //Validation



            Category category = _categoryDao.find(id);

            //Message Category
            return category;
        }

        public List<Category> findAll()
        {
            //Validation



            List<Category> categoryies = _categoryDao.findAll();

            //Message Category
            return categoryies;
        }

        public string delete(string id)
        {
            Category category = new Category();


            category = _categoryDao.find(id);
            if (category == null)
            {
                return "Category does not exist";
            }

            
            return _categoryDao.delete(category);
        }
    }
}
