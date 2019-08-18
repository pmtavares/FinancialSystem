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
    public class SalerDao
    {
        private readonly ConnectionDb _connectionDB;
        private SqlCommand _command;


        public SalerDao()
        {
            _connectionDB = ConnectionDb.getStatus();
        }
        public void create(Saler saler)
        {
            string create = string.Format("INSERT INTO saler(name, pps, phone) " +
                "VALUES ({0}, {1}, {2})", saler.name, saler.pps, saler.phone);
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

        public void createSP(Saler saler)
        {
            //"sp_addsaler{1},{2},{3},{4}", + saler.idsaler + "," + saler.name + ", " + saler.address + "," + saler.pps ;
            string create = string.Format("sp_addsaler '{0}','{1}','{2}'", saler.name, saler.pps, saler.phone);
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

        public string delete(Saler saler)
        {
            string resp;
            SqlConnection SqlCon = _connectionDB.GetCon();
            try
            {
                SqlCon.Open();


                _command = new SqlCommand();

                //SqlCommand SqlCmd = new SqlCommand();

                _command.Connection = SqlCon;
                _command.CommandText = "sp_deletesaler";
                _command.CommandType = CommandType.StoredProcedure;

                //Initialize variables
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@code"; //same name as in the procedure
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = saler.idSaler;

                _command.Parameters.Add(ParId);

                //Execute the command
                resp = _command.ExecuteNonQuery() == 1 ? "Saler deleted" : "Not deleted";

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
            return resp;
        }

        public Saler find(string salerId)
        {
            Saler saler = new Saler();
            string find = string.Format("SELECT * FROM saler WHERE idsaler = {0} ", salerId);
            try
            {
                _command = new SqlCommand(find, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.Read())
                {
                    saler.idSaler = reader[0].ToString();
                    saler.name = reader[1].ToString();
                    saler.pps = reader[2].ToString();
                    saler.phone = reader[3].ToString();
                    
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
            return saler;
        }

        public List<Saler> findAll()
        {

            List<Saler> salerList = new List<Saler>();
            string showAll = "SELECT * FROM saler ORDER BY idSaler ASC";
            try
            {
                _command = new SqlCommand(showAll, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();


                while (reader.Read())
                {
                    Saler salerReceived = new Saler();
                    salerReceived.idSaler = reader[0].ToString();

                    salerReceived.name = reader[1].ToString();
                    salerReceived.pps = reader[2].ToString();
                    salerReceived.phone = reader[3].ToString();
 

                    salerList.Add(salerReceived);
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
            return salerList;

        }

        public void update(Saler saler)
        {
            string update = string.Format("UPDATE saler set name='{0}', phone='{1}', pps='{2}' where idsaler={3}",
                saler.name, saler.pps, saler.phone, saler.idSaler);

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

        public void updateSP(Saler saler)
        {
            string updateOld = string.Format("UPDATE saler set name='{0}', pps='{1}', phone='{2}' where idsaler={3}",
                saler.name, saler.pps, saler.phone, saler.idSaler);
            string update = string.Format("sp_updatesaler '{0}','{1}','{2}','{3}'", saler.idSaler, saler.name, saler.pps, saler.phone);
            try
            {
                _command = new SqlCommand(update, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();
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

        public bool findsalerByPps(Saler saler)
        {
            bool temRecord = false;
            string find = string.Format("SELECT * FROM saler WHERE pps={0}", saler.pps);

            try
            {
                _command = new SqlCommand(find, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();
                temRecord = reader.Read();
                


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

        public List<Saler> findAllSaler(string name, string code, string pps)
        {

            List<Saler> salerList = new List<Saler>();
            string showAll = string.Format("SELECT * FROM saler WHERE name like '%{0}%' OR idSaler = '{1}' OR pps LIKE '%{2}%' ORDER BY name ASC", name, code, pps);
            try
            {
                _command = new SqlCommand(showAll, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();


                while (reader.Read())
                {
                    Saler salerReceived = new Saler();
                    salerReceived.idSaler = reader[0].ToString();

                    salerReceived.name = reader[1].ToString();
                    salerReceived.pps = reader[2].ToString();
                    salerReceived.phone = reader[3].ToString();


                    salerList.Add(salerReceived);
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
            return salerList;

        }



    }
}

