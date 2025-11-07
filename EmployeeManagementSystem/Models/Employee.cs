namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Salary Salary { get; set; }= new Salary();

        public DateTime HireDate { get; set; }= DateTime.Now;

        public int DepartmentId { get; set; }

        public string Designation { get; set; } = string.Empty;
        public Department Department { get; set; }= new Department();
        public ICollection<Salary> Salaries { get; set; } 

        //
    }

}
