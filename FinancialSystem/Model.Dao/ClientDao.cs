using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClientDao : Required<Client>
    {

        private readonly ConnectionDb _connectionDB;
        private SqlCommand _command;


        public ClientDao()
        {
            _connectionDB = ConnectionDb.getStatus();
        }
        public void create(Client client)
        {
            string create = string.Format($"INSERT INTO client(name, address, phone, pps) " +
                "VALUES ({1}, {2}, {3}, {4})", client.name, client.address, client.phone, client.pps);
            try
            {

            }
            catch(SqlException sql)
            {

            }
        }

        public void delete(Client client)
        {
            throw new NotImplementedException();
        }

        public void find(Client client)
        {
            throw new NotImplementedException();
        }

        public List<Client> findAll()
        {
            throw new NotImplementedException();
        }

        public void update(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
