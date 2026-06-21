using DataLayer.Abstract;
using DataLayer.Models;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.Repos
{
    public class NurseRepo : INurse
    {
        SqlConnection sqlConnection = new SqlConnection("Server=localhost;Database=Nurse;Integrated Security=True");
        public List<Nurse> GetAllNurse()
        {
            List<Nurse> nurses = new List<Nurse>();
            SqlCommand sqlCommand = new SqlCommand("GetNursesDetails", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();

            foreach (DataRow row in dataTable.Rows)
            {
                Nurse nurse = new Nurse();
                nurse.HId = Convert.ToInt32(row["HId"]);
                nurse.Name = row["Name"].ToString();
                nurse.Dept = row["Dept"].ToString();

                nurses.Add(nurse);
            }

            return nurses;
        }
    }
}
