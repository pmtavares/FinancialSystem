using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Product
    {
        public string idProduct { get; set; }

        public string name { get; set; }

        public double unitPrice { get; set; }

        public string category { get; set; }

        public int status { get; set; }

        public Product()
        {

        }

        public Product(string name, double price, string cat )
        {
            this.name = name;
            this.unitPrice = price;
            this.category = cat;
        }
    }
}
