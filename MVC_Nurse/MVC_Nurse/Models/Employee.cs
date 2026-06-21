namespace MVC_Nurse.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime JoiningDate { get; set; }
        public int Salary { get; set; }

        public Employee GetEmp()
        {
            return new Employee
            {
                EmpId = 1,
                EmpName = "Sumit",
                JoiningDate = DateTime.Now,
                Salary = 5000
            };
        }
    }
}
