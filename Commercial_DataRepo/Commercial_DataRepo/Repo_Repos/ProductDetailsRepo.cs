using System.Data;
using System.Data.SqlClient;
using Commercial_DataRepo.Repo_Interface;
using Commercial_DataRepo.Repo_Models;

namespace Commercial_DataRepo.Repo_Repos
{
    public class ProductDetailsRepo : IProductDetails
    {
        SqlConnection sqlConnection = new SqlConnection("Server=localhost;Database=Commercial;Trusted_Connection=True;");
        public string AddProductDetails(ProductDetail productDetail)
        {
            string msg = string.Empty;
            SqlCommand sqlCommand = new SqlCommand("PurchageDatilsStoredProc", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@PuQty", productDetail.PuQty);
            sqlCommand.Parameters.AddWithValue("@PId", productDetail.PId);

            // Output parameter
            SqlParameter outputParam = new SqlParameter("@msg", SqlDbType.NVarChar, 255)
            {
                Direction = ParameterDirection.Output
            };

            sqlCommand.Parameters.Add(outputParam);

            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            // Retrieve output value
            var outMessage = sqlCommand.Parameters["@msg"].Value;
            if (outMessage != null && outMessage != DBNull.Value)
            {
                msg = outMessage.ToString();
            }

            sqlConnection.Close();

            return msg;
        }
    }
}

