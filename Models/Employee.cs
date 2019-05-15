using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRV7.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Date of hire")]
        public DateTime DateOfHire { get; set; }
        [Required(ErrorMessage ="Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Deparment")]
        public string Department { get; set; }
        [Required(ErrorMessage ="Employment Type")]
        [Column(TypeName = "varchar(3)")]
        public string EmploymentType { get; set; }
        [Required(ErrorMessage ="Vacation Days")]
        public int VacationDays { get; set; }
        [Required(ErrorMessage ="Sick Days")]
        public int SickDays { get; set; }
        [Required(ErrorMessage ="Bereavement Days")]
        public int BereavementDays { get; set; }
        
    }
}
