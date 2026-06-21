using Nurse_data.Abstract;
using Nurse_data.Models;
using System.Data;
using System.Data.SqlClient;

namespace Nurse_data.NurseRepo
{
    public class NurseRepo : INurseRepo
    {
        SqlConnection sqlConnection = new SqlConnection("Server=localhost;Database=Nurse;Trusted_Connection=True;");

        public List<Nurse> GetAllNurse()
        {
            List<Nurse> nurses = new List<Nurse>();

            SqlCommand sqlCommand = new SqlCommand("GetNursesDetails", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Nurse nurse = new Nurse();
                nurse.HId = Convert.ToInt32(row["HId"]);
                nurse.Name = row["Name"].ToString();
                nurse.Dept = row["Dept"].ToString();
                nurse.Gender = row["Gender"].ToString();

                nurses.Add(nurse);
            }

            return nurses;
        }

        public Nurse GetNurseById(int hid)
        {
            Nurse nurse = new Nurse();

            SqlCommand sqlCommand = new SqlCommand("GetNurseByHid", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Hid", hid);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                // Nurse nurse = new Nurse();
                nurse.HId = hid;
                nurse.Name = row["Name"].ToString();
                nurse.Dept = row["Dept"].ToString();
                nurse.Gender = row["Gender"].ToString();  
            }

            return nurse;
        }
        

        public int InsertNurse(Nurse nurse)
        {

            SqlCommand sqlCommand = new SqlCommand("InsertNurseDetails", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Name", nurse.Name);
            sqlCommand.Parameters.AddWithValue("@Dept", nurse.Dept);
            sqlCommand.Parameters.AddWithValue("@Gender", nurse.Gender);

            sqlConnection.Open();

            int recordCount = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return recordCount;
        }

        public int UpdateNurse(Nurse nurse)
        {
            SqlCommand sqlCommand = new SqlCommand("UpdateNure", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Name", nurse.Name);
            sqlCommand.Parameters.AddWithValue("@Dept", nurse.Dept);
            sqlCommand.Parameters.AddWithValue("@Gender", nurse.Gender);
            sqlCommand.Parameters.AddWithValue("@Hid", nurse.HId);

            sqlConnection.Open();

            int recordCount = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();


            return recordCount;
        }

        public int DeleteNurse(int hid)
        {
            SqlCommand sqlCommand = new SqlCommand("DeleteNurse", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Hid", hid);
    
            sqlConnection.Open();

            int recordCount = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return recordCount;
        }
    }
}

