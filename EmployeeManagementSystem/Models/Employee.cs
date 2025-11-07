namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public decimal Salary { get; set; }= 0;

        public DateTime HireDate { get; set; }= DateTime.Now;

        public int DepartmentId { get; set; } 

        public Department Department { get; set; }= new Department();
    }
}
