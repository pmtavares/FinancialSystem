using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Refactor this code
 */
namespace Model.BUS.Util
{
    public class Messages<ClassType> where ClassType: class
    {
        private readonly string objName;
        public Messages(string name)
        {
            objName = name;
        }

        public string ErrorMessageRegister(int code)
        {

            switch (code)
            {

                case 1000:
                    return "Erro PPS, Dont insert letters";


                case 20:
                    return "Insert"+ objName + "name";


                case 2:
                    return "Name cannot be more than 30 characteres";

                case 50:
                    return "Please put a PPS";


                case 60:
                    return "Please insert the address";

                case 6:
                    return "Address can not contain more than 50 characteres";


                case 8:
                    return "Client already exists";

                case 3:
                    return "Phone number is required";

                case 35:
                    return "Phone lenght is incorrect";

                default:
                    return "Unknown error";




            }
        }

        public string CreatedMessage(string msg)
        {
            return msg;
        }
    }
}
