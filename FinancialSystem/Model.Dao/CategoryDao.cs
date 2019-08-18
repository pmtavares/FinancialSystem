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
    public class CategoryDao
    {
        private readonly ConnectionDb _connectionDB;
        private SqlCommand _command;

        public CategoryDao()
        {
            _connectionDB = ConnectionDb.getStatus();
        }

        public void Create(Category category)
        {
            string create = string.Format("INSERT INTO category(idCategory, name, description, status) VALUES ({0}, {1}, {2}, {3})", 
                category.idCategory, category.name, category.description, category.status);
            try
            {
                _command = new SqlCommand(create, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();
                _command.ExecuteNonQuery();
            }
            catch(SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connectionDB.GetCon().Close();
                _connectionDB.CloseDB();
            }
        }

        public void CreateSP(Category category)
        {
            string create = string.Format("sp_addCategory '{0}', '{1}', '{2}'", category.idCategory, category.name, category.description);
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

        public Category find(string categoryId)
        {
            Category category = new Category();
            string find = string.Format("SELECT TOP (500) * FROM category WHERE idCategory = {0}", categoryId);

            try
            {
                _command = new SqlCommand(find, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.Read())
                {
                    category.idCategory = reader[0].ToString();
                    category.name = reader[1].ToString();
                    category.description = reader[2].ToString();

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
            return category;
        }

        public List<Category> findAll()
        {

            List<Category> categoryList = new List<Category>();
            string showAll = "SELECT * FROM category ORDER BY name ASC";
            try
            {
                _command = new SqlCommand(showAll, _connectionDB.GetCon());
                _connectionDB.GetCon().Open();

                SqlDataReader reader = _command.ExecuteReader();


                while (reader.Read())
                {
                    Category categoryReceived = new Category();


                    categoryReceived.idCategory = reader[0].ToString();
                    categoryReceived.name = reader[1].ToString();
                    categoryReceived.description = reader[2].ToString();
                    categoryList.Add(categoryReceived);
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
            return categoryList;

        }

        public void update(Category category)
        {
            string update = string.Format("UPDATE category set name='{0}', description='{1}' where idCategory={2}",
                category.name, category.description, category.idCategory);

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

        public string delete(Category category)
        {
            string resp;
            try
            {
                _connectionDB.GetCon().Open();

                _command = new SqlCommand();

                _command.Connection = _connectionDB.GetCon();
                _command.CommandText = "sp_deleteCategory";
                _command.CommandType = CommandType.StoredProcedure;

                //Initialize variables
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@code"; //same name as in the procedure
                ParId.SqlDbType = SqlDbType.VarChar;
                ParId.Value = category.idCategory;

                _command.Parameters.Add(ParId);

                //Execute the command
                resp = _command.ExecuteNonQuery() == 1 ? "Category Deleted" : "Not deleted";

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
