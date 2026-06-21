using System.Data;
using System.Data.SqlClient;

namespace EMPLOYEDIR.Models
{
    public class Employe
    {
        public int EMPID { get; set; }
        public string EMPNAME { get; set; }
        public string Location { get; set; }

        //public Employe() { }
        //public Employe(int empId, string empName, string location)
        //{
        //    EMPID = empId;
        //    EMPNAME = empName;
        //    Location = location;
        //}

        SqlConnection sqlConnection = new SqlConnection("Server=localhost;Database=Employe;Trusted_Connection=True;");
        public Employe GetEmploye(int empId)
        {
            Employe employe = new Employe();

            SqlCommand sqlCommand = new SqlCommand("GETEMPLOYE", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            DataTable dataTable = new DataTable();
            sqlCommand.Parameters.AddWithValue("@EMPID", empId);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            employe.EMPID = dataTable.Rows[0]["EMPID"] != DBNull.Value ? Convert.ToInt32(dataTable.Rows[0]["EMPID"]) : 0;   
            employe.EMPNAME = dataTable.Rows[0]["EMPNAME"] != DBNull.Value ? dataTable.Rows[0]["EMPNAME"].ToString() : string.Empty;
            employe.Location = dataTable.Rows[0]["Location"] != DBNull.Value ? dataTable.Rows[0]["Location"].ToString() : string.Empty;

            return employe;
        }
    }
}
