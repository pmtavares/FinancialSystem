using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BUS.Util
{
    public interface IMessages<ClassType> where ClassType : class
    {
        string ErrorMessages(int code);

        string SuccessMessage(string msg);

    }
}
