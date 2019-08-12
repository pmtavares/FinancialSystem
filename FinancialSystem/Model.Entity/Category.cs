using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Category
    {
        public string idCategory { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int status { get; set; }

        public Category()
        {

        }

        public Category(string id, string name, string description)
        {
            this.idCategory = id;
            this.name = name;
            this.description = description;

        }
    }
}
