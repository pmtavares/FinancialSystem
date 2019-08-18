using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Saler
    {
        public string idSaler { get; set; }
        public string name { get; set; }

        public string pps { get; set; }
        public string phone { get; set; }
        public int status { get; set; }

        public Saler()
        {

        }

        public Saler(string id)
        {
            idSaler = id;
        }
        public Saler(string id, string nameSaler, string ppsNumber)
        {
            idSaler = id;
            name = nameSaler;
            pps = ppsNumber;
        }
    }
}
