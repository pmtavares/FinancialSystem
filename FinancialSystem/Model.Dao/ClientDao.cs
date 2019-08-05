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
            string create = string.Format($"INSERT INTO client(name, address, phone, pps) " +
                "VALUES ({1}, {2}, {3}, {4})", client.name, client.address, client.phone, client.pps);
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
            string create = string.Format($"sp_addClient {1},{2},{3},{4}", client.name, client.address,client.phone, client.pps);
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
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                _command = new SqlCommand();

                SqlCommand SqlCmd = new SqlCommand();

                _command.Connection = _connectionDB.GetCon();
                _command.CommandText = "sp_deleteClient";
                _command.CommandType = CommandType.StoredProcedure;

                //Initialize variables
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@code"; //same name as in the procedure
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = client.idClient;

                SqlCmd.Parameters.Add(ParId);

                //Execute the command
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Not deleted";

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

        public bool find(Client client)
        {
            bool temRecords = false;
            string find = string.Format($"SELECT * FROM client WHERE idClient = {1} ", client.idClient);
            try
            {
                _command = new SqlCommand(find, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();
                temRecords = reader.Read();

                if(temRecords)
                {
                    client.name = reader[1].ToString();
                    client.address = reader[2].ToString();
                    client.phone = reader[3].ToString();
                    client.pps = reader[4].ToString();
                }

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
            return temRecords;
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
            return clientList;

        }

        public void update(Client client)
        {
            string update = string.Format($"UPDATE client set name={1}, address={2}, phone={3}, pps={4}",
                client.name, client.address, client.phone, client.pps);

            try
            {
                _command = new SqlCommand(update, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();
              

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

        public bool findClientByPps(Client client)
        {
            bool temRecord = false;
            string find = string.Format($"SELECT * FROM client WHERE pps={1}", client.pps);

            try
            {
                _command = new SqlCommand(find, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();
                temRecord = reader.Read();
                if(temRecord)
                {
                    client.idClient = Convert.ToInt64(reader[0].ToString());

                    client.name = reader[1].ToString();
                    client.address = reader[2].ToString();
                    client.phone = reader[3].ToString();
                    client.pps = reader[4].ToString();
                }

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

            return temRecord;
        }

        public List<Client> findAllClient(string name)
        {

            List<Client> clientList = new List<Client>();
            string showAll = string.Format($"SELECT * FROM client WHERE name like %{1}% ORDER BY name ASC", name);
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
            return clientList;

        }

    }
}
