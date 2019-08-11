using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
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
            string create = string.Format("INSERT INTO client(name, address, phone, pps) " +
                "VALUES ({0}, {1}, {2}, {3})", client.name, client.address, client.phone, client.pps);
            try
            {
                _command = new SqlCommand(create, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();
                _command.ExecuteNonQuery();
            }
            catch(SqlException sql)
            {
                
                Console.WriteLine(sql);
                throw sql;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                _connectionDB.GetCon().Close();
                _connectionDB.CloseDB();
            }
        }

        public void createSP(Client client)
        {
            //"sp_addClient{1},{2},{3},{4}", + client.idClient + "," + client.name + ", " + client.address + "," + client.pps ;
            string create = string.Format("sp_addClient '{0}','{1}','{2}','{3}'", client.name, client.address,client.phone, client.pps);
            try
            {
                _command = new SqlCommand(create, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();
                _command.ExecuteNonQuery();
            }
            catch (SqlException sql)
            {

                Console.WriteLine(sql);
                throw sql;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                _connectionDB.GetCon().Close();
                _connectionDB.CloseDB();
            }
        }

        public void delete(Client client)
        {
            string resp;
            SqlConnection SqlCon = _connectionDB.GetCon();
            try
            {
                SqlCon.Open();


                _command = new SqlCommand();

                //SqlCommand SqlCmd = new SqlCommand();

                _command.Connection = SqlCon;
                _command.CommandText = "sp_deleteClient";
                _command.CommandType = CommandType.StoredProcedure;

                //Initialize variables
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@code"; //same name as in the procedure
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = client.idClient;

                _command.Parameters.Add(ParId);

                //Execute the command
                resp = _command.ExecuteNonQuery() == 1 ? "OK" : "Not deleted";

            }
            catch (SqlException sql)
            {

                Console.WriteLine(sql);
                throw sql;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                _connectionDB.GetCon().Close();
                _connectionDB.CloseDB();
            }
        }

        public Client find(long clientId)
        {
            Client client = new Client();
            string find = string.Format("SELECT * FROM client WHERE idClient = {0} ", clientId);
            try
            {
                _command = new SqlCommand(find, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();                

                if(reader.Read())
                {
                    client.idClient = Convert.ToInt64(reader[0].ToString());
                    client.name = reader[1].ToString();
                    client.address = reader[2].ToString();
                    client.phone = reader[3].ToString();
                    client.pps = reader[4].ToString();
                }

                
            }
            catch (SqlException sql)
            {

                Console.WriteLine(sql);
                throw sql;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                _connectionDB.GetCon().Close();
                _connectionDB.CloseDB();
            }
            return client;
        }

        public List<Client> findAll()
        {

            List<Client> clientList = new List<Client>();
            string showAll = "SELECT * FROM client ORDER BY name ASC";
            try
            {
                _command = new SqlCommand(showAll, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();


                while (reader.Read())
                {
                    Client clientReceived = new Client();
                    clientReceived.idClient = Convert.ToInt64(reader[0].ToString());

                    clientReceived.name = reader[1].ToString();
                    clientReceived.address = reader[2].ToString();
                    clientReceived.phone = reader[3].ToString();
                    clientReceived.pps = reader[4].ToString();

                    clientList.Add(clientReceived);
                }

               
            }
            catch (SqlException sql)
            {

                Console.WriteLine(sql);
                throw sql;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                _connectionDB.GetCon().Close();
                _connectionDB.CloseDB();
            }
            return clientList;

        }

        public void update(Client client)
        {
            string update = string.Format("UPDATE client set name='{0}', address='{1}', phone='{2}', pps='{3}' where idClient={4}",
                client.name, client.address, client.phone, client.pps, client.idClient);

            try
            {
                _command = new SqlCommand(update, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();
              

            }
            catch (SqlException sql)
            {

                Console.WriteLine(sql);
                throw sql;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                _connectionDB.GetCon().Close();
                _connectionDB.CloseDB();
            }
        }

        public void updateSP(Client client)
        {
            string updateOld = string.Format("UPDATE client set name='{0}', address='{1}', phone='{2}', pps='{3}' where idClient={4}",
                client.name, client.address, client.phone, client.pps, client.idClient);
            string update = string.Format("sp_updateClient '{0}','{1}','{2}','{3}', '{4}'", client.idClient, client.name, client.address, client.phone, client.pps);
            try
            {
                _command = new SqlCommand(update, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();
                //SqlDataReader reader = _command.ExecuteReader();
                _command.ExecuteNonQuery(); //No need to return anything
            }
            
            catch (SqlException sql)
            {

                Console.WriteLine(sql);
                throw sql;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                _connectionDB.GetCon().Close();
                _connectionDB.CloseDB();
            }
        }

        public bool findClientByPps(Client client)
        {
            bool temRecord = false;
            string find = string.Format("SELECT * FROM client WHERE pps={0}", client.pps);

            try
            {
                _command = new SqlCommand(find, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();
                temRecord = reader.Read();
                /*if(temRecord)
                {
                    client.idClient = Convert.ToInt64(reader[0].ToString());

                    client.name = reader[1].ToString();
                    client.address = reader[2].ToString();
                    client.phone = reader[3].ToString();
                    client.pps = reader[4].ToString();
                } */

                
            }
            catch (SqlException sql)
            {

                Console.WriteLine(sql);
                throw sql;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                _connectionDB.GetCon().Close();
                _connectionDB.CloseDB();
            }

            return temRecord;
        }

        public List<Client> findAllClient(string name, string code, string pps)
        {

            List<Client> clientList = new List<Client>();
            string showAll = string.Format("SELECT * FROM client WHERE name like '%{0}%' OR idclient = '{1}' OR pps LIKE '%{2}%' ORDER BY name ASC", name, code, pps);
            try
            {
                _command = new SqlCommand(showAll, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();


                while (reader.Read())
                {
                    Client clientReceived = new Client();
                    clientReceived.idClient = Convert.ToInt64(reader[0].ToString());

                    clientReceived.name = reader[1].ToString();
                    clientReceived.address = reader[2].ToString();
                    clientReceived.phone = reader[3].ToString();
                    clientReceived.pps = reader[4].ToString();

                    clientList.Add(clientReceived);
                }

                
            }
            catch (SqlException sql)
            {

                Console.WriteLine(sql);
                throw sql;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                _connectionDB.GetCon().Close();
                _connectionDB.CloseDB();
            }
            return clientList;

        }

       

    }
}
