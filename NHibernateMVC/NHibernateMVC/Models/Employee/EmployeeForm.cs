using System;

namespace NHibernateMVC.Models.Employee
{
    public class EmployeeForm
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Sex { get; set; }
        public Guid? ManagerId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string County { get; set; }
        public string ZipCode { get; set; }

        public EmployeeForm(EmployeeForm employeeForm)
        {
            EmployeeId = employeeForm.EmployeeId;
            FirstName = employeeForm.FirstName;
            LastName = employeeForm.LastName;
            BirthDate = employeeForm.BirthDate;
            Sex = employeeForm.Sex;
            ManagerId = employeeForm.ManagerId;
            City = employeeForm.City;
            Street = employeeForm.Street;
            County = employeeForm.County;
            ZipCode = employeeForm.ZipCode;
        }

        public EmployeeForm() { }

        public class EmployeeInfoViewModel
        {
            public Guid EmployeeId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
            public int Sex { get; set; }
            public Guid? ManagerId { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string County { get; set; }
            public string ZipCode { get; set; }
        }
    }

    
}