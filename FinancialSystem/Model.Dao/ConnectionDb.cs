using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    class ConnectionDb
    {
        private static ConnectionDb _objConnectionDb = null;
        private SqlConnection _con;

        private ConnectionDb()
        {
            _con = new SqlConnection("Data Source=DESKTOP-8OSEUIG\\SQLExpress;Initial Catalog=FinancialDb; Integrated Security=True");
        }

        public static ConnectionDb getStatus()
        {
            if(_objConnectionDb == null)
            {
                _objConnectionDb = new ConnectionDb();
            }
            return _objConnectionDb;
        }

        public SqlConnection GetCon()
        {
            return _con;
        }

        public void CloseDB()
        {
            _objConnectionDb = null;
        }

    }
}
