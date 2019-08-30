using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        private readonly ConnectionDb _connectionDB;
        private SqlCommand _command;


        public ProductDao()
        {
            _connectionDB = ConnectionDb.getStatus();
        }

        public void create(Product product)
        {
            string create = string.Format("INSERT INTO product(idProduct, name, priceunit, idcategory) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}')",product.idProduct, product.name, product.unitPrice, product.category);
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

        public string delete(Product product)
        {
            string resp;
            SqlConnection SqlCon = _connectionDB.GetCon();
            string delete = "DELETE FROM product WHERE idproduct='" + product.idProduct+ "'";
            try
            {
                _command = new SqlCommand(delete, SqlCon);
                _connectionDB.GetCon().Open();

                //Execute the command
                resp = _command.ExecuteNonQuery() == 1 ? "Product deleted" : "Not deleted";

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

        public Product find(string id)
        {
            Product product = new Product();
            string find = string.Format("SELECT * FROM product WHERE idproduct = '{0}' ", id);
            try
            {
                _command = new SqlCommand(find, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.Read())
                {
                    product.idProduct = reader[0].ToString();
                    product.name = reader[1].ToString();
                    product.unitPrice =  Convert.ToDouble(reader[2].ToString());
                    product.category = reader[3].ToString();

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
            return product;
        }

        public List<Product> findAll()
        {

            List<Product> productList = new List<Product>();
            string showAll = "SELECT * FROM product ORDER BY idproduct ASC";
            try
            {
                _command = new SqlCommand(showAll, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();


                while (reader.Read())
                {
                    Product productReceived = new Product();
                    productReceived.idProduct = reader[0].ToString();

                    productReceived.name = reader[1].ToString();
                    productReceived.unitPrice = Convert.ToDouble(reader[2].ToString());
                    productReceived.category = reader[3].ToString();


                    productList.Add(productReceived);
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
            return productList;

        }

        public void update(Product product)
        {
            string update = string.Format("UPDATE product set name='{0}', priceunit='{1}', idcategory='{2}' where idproduct='{3}'",
                product.name, product.unitPrice, product.category, product.idProduct);

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
    }
}
