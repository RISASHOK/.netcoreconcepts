using System.Data;
using System.Data.SqlClient;
using Commercial_DataRepo.Repo_Interface;
using Commercial_DataRepo.Repo_Models;

namespace Commercial_DataRepo.Repo_Repos
{
    public class ProductRepo : IProduct
    {
        SqlConnection sqlConnection = new SqlConnection("Server=localhost;Database=Commercial;Trusted_Connection=True;");

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            SqlCommand sqlCommand = new SqlCommand("GetProductData", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Product product = new Product();
                product.SQty = Convert.ToInt32(row["SQty"]);
                product.PName = row["PName"].ToString();
                product.PId = Convert.ToInt32(row["PId"]);

                products.Add(product);
            }

            return products;
        }

        public int InsertNewProduct(Product product)
        {

            SqlCommand sqlCommand = new SqlCommand("InsertProductDetails", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            //sqlCommand.Parameters.AddWithValue("@PId", product.Pid);
            sqlCommand.Parameters.AddWithValue("@PName", product.PName);
            sqlCommand.Parameters.AddWithValue("@SQty", product.SQty);
          

            sqlConnection.Open();

            int recordCount = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return recordCount;
        }

        public Product GetProductById(int pid)
        {
            Product product = new Product();

            SqlCommand sqlCommand = new SqlCommand("GetProductByPId", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@PId", pid);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                // Nurse nurse = new Nurse();
                product.PId = pid;
                product.PName = row["PName"].ToString();
                product.SQty = Convert.ToInt32(row["SQty"].ToString());
            }

            return product;
        }

        public int DeleteProduct(int pid)
        {
            SqlCommand sqlCommand = new SqlCommand("DeleteProduct", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@PId", pid);

            sqlConnection.Open();

            int recordCount = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return recordCount;
        }
    }
}
