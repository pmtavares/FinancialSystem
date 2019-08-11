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
    //public class Messages<ClassType> where ClassType: class //IMessages
    public class ClientMessages: IMessages<Client>
    {
        private readonly string objName;
        public ClientMessages(string name)
        {
            objName = name;
        }

              

        public string ErrorMessages(int code)
        {
            switch (code)
            {

                case 1000:
                    return "Erro PPS, Dont insert letters";

                case 20:
                    return "Insert" + objName + "name";

                case 2:
                    return "Name cannot be more than 30 characteres";

                case 50:
                    return "Please put a PPS";

                case 55:
                    return "PPS must contain between 8 and 9 characteres";
                case 58:
                    return "PPS already exists";
                case 59:
                    return "PPS does not exists";
                case 60:
                    return "Please insert the address";

                case 6:
                    return "Address can not contain more than 50 characteres";


                case 8:
                    return "Client already exists";
                case 9:
                    return "Client does not exists";

                case 3:
                    return "Phone number is required";

                case 35:
                    return "Phone lenght is incorrect";
                case 95:
                    return "Error deleting the client";

                default:
                    return "Unknown error";


            }
        }

        public string SuccessMessage(string msg)
        {
            return msg;
        }
    }
}
