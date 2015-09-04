using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NHibernateMVC.Models.Employee
{
    /// <summary>
    /// Form data for employee creation/editing
    /// </summary>
    public class EmployeeForm
    {
        /// <summary>
        /// Employee id - Guid
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Employee first name
        /// </summary>
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        /// <summary>
        /// Employee Last name
        /// </summary>
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        /// <summary>
        /// Employee birth date
        /// </summary>
        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// employee gender
        /// </summary>
        [Required]
        public int Sex { get; set; }
        /// <summary>
        /// employee Mangager Id uniq
        /// </summary>
        public Guid? ManagerId { get; set; }
        /// <summary>
        /// Employee Adres - City
        /// </summary>
        [Required, MaxLength(50)]
        public string City { get; set; }
        /// <summary>
        /// Employee Adres - Street
        /// </summary>
        [Required, MaxLength(50)]
        public string Street { get; set; }
        /// <summary>
        /// Employee Adres - Country
        /// </summary>
        [Required, MaxLength(50)]
        public string County { get; set; }
        /// <summary>
        /// Employee Adres - Zip Code
        /// </summary>
        [Required, MaxLength(50)]
        public string ZipCode { get; set; }
        /// <summary>
        /// Employee projects
        /// </summary>
        public List<Domain.Project.Project> Projects { get; set; }
        /// <summary>
        /// List of all projects in company
        /// </summary>
        public List<Domain.Project.Project> AllProjects { private get; set; }
        /// <summary>
        /// enum for employee gender choose
        /// </summary>
        public enum SexEnum
        {
            Male=1,
            Female=2
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="employeeForm"></param>
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
            Projects = employeeForm.Projects;
            AllProjects = employeeForm.AllProjects;
        }
        /// <summary>
        /// empty constructor
        /// </summary>
        public EmployeeForm() { }
    }  
}