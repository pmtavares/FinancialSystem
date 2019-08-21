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
    public class MethodPaymentDao
    {
        private readonly ConnectionDb _connectionDB;
        private SqlCommand _command;

        public MethodPaymentDao()
        {
            _connectionDB = ConnectionDb.getStatus();
        }

        public void Create(MethodPayment method)
        {
            string create = string.Format("INSERT INTO methodPayment(name, othersdetails) VALUES ('{0}', '{1}')",
                method.name, method.othersDetails);
            try
            {
                _command = new SqlCommand(create, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();
                _command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connectionDB.GetCon().Close();
                _connectionDB.CloseDB();
            }
        }

        

        public MethodPayment find(int id)
        {
            MethodPayment method = new MethodPayment();
            string find = string.Format("SELECT TOP (500) * FROM methodPayment WHERE numPay = {0}", id);

            try
            {
                _command = new SqlCommand(find, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.Read())
                {
                    method.numPay = Convert.ToInt32(reader[0].ToString());
                    method.name = reader[1].ToString();
                    method.othersDetails = reader[2].ToString();

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
            return method;
        }

        public List<MethodPayment> findAll()
        {

            List<MethodPayment> methodPayment = new List<MethodPayment>();
            string showAll = "SELECT * FROM methodPayment ORDER BY name ASC";
            try
            {
                _command = new SqlCommand(showAll, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();


                while (reader.Read())
                {
                    MethodPayment method = new MethodPayment();


                    method.numPay = Convert.ToInt32(reader[0].ToString());
                    method.name = reader[1].ToString();
                    method.othersDetails = reader[2].ToString();
                    methodPayment.Add(method);
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
            return methodPayment;

        }

        public void update(MethodPayment method)
        {
            string update = string.Format("UPDATE methodPayment set name='{0}', othersdetails='{1}' where numPay={2}",
                method.name, method.othersDetails, method.numPay);

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

        public string delete(MethodPayment method)
        {
            string resp;
            try
            {
                _connectionDB.GetCon().Open();

                _command = new SqlCommand();

                _command.Connection = _connectionDB.GetCon();
                _command.CommandText = "sp_deleteMethodPayment";
                _command.CommandType = CommandType.StoredProcedure;

                //Initialize variables
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@code"; //same name as in the procedure
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = method.numPay;

                _command.Parameters.Add(ParId);

                //Execute the command
                resp = _command.ExecuteNonQuery() == 1 ? "Method Deleted" : "Not deleted";

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
    }
}
