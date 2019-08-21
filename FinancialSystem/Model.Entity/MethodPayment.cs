using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class MethodPayment
    {
        public int numPay { get; set; }
        public string name { get; set; }
        public string othersDetails { get; set; }
        public int status { get; set; }

        public MethodPayment()
        {

        }

        public MethodPayment(int number, string name, string others)
        {
            this.numPay = number;
            this.name = name;
            this.othersDetails = others;
        }
    }
}
