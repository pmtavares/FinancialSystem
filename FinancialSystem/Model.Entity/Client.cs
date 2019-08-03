using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Client
    {

        [Display(Name="Code")]
        public long idClient { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Field name is required")]
        public string name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Field address is required")]
        public string address { get; set; }
        public string phone { get; set; }

        [Display(Name = "PPS")]
        public string pps { get; set; }

        public Client() { }

        public Client(long idClient)
        {
            this.idClient = idClient;
        }

        public Client(long idClient, string name, string pps, string address)
        {
            this.idClient = idClient;
            this.name = name;
            this.pps = pps;
            this.address = address;

        }

    }
}
