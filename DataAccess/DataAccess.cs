using MVPPatternModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccess : IDataAccessRepo
    {
        string connectionString = string.Empty;
   
        public DataAccess(string connectionstring)
        {
            //TODO:
            //ConnectionString parameterden gelmeseydi yani aşağıdaki gibi olsaydı nasıl test ederdik?
            //connectionstring= ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            if (string.IsNullOrEmpty(connectionstring))
                throw new ArgumentNullException("ArgumentNullException");
            connectionString = connectionstring;
        }
        public Product Select(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            Product product = null;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand();
                command.CommandText = "Select ProductID,ProductName,UnitPrice,UnitsInStock,QuantityPerUnit from Products where ProductID=@Id";
                command.Connection = connection;
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product()
                        {
                            ProductId = (int)reader["ProductID"],
                            ProductName = (string)reader["ProductName"],
                            Price = (decimal)reader["UnitPrice"],
                            Stok = (short)reader["UnitsInStock"],
                            QuantityPerUnit = (string)reader["QuantityPerUnit"]
                        };
                    }
                }
            }
            return product;
        }

        public IEnumerable<Product> SelectAll()
        {
            
            var productList = new List<Product>();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand();
                command.CommandText = "Select ProductID,ProductName,UnitPrice,UnitsInStock,QuantityPerUnit from Products";
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productList.Add(new Product()
                        {
                           ProductId=(int)reader["ProductID"],// reader.IsDBNull((int)reader["ProductID"]) ? (int?)null : (int)reader["ProductID"],      
                            ProductName = (string)reader["ProductName"],
                            Price = (decimal)reader["UnitPrice"],
                            Stok = (short)reader["UnitsInStock"],
                            QuantityPerUnit = (string)reader["QuantityPerUnit"]
                        });
                    }
                }
            }

            return productList;
        }


    }


}
