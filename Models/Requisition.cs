using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRV7.Models
{
    public class Requisition
    {
        [Key]
        public int RequisitionId { get; set; }
        [ForeignKey("EmployeeFK")]
        [Required(ErrorMessage = "Employee Id")]
        public int EmployeeFK { get; set; }
        [Required(ErrorMessage = "Date Requested")]
        public DateTime DateRequested { get; set; }
        [Required(ErrorMessage = "Time Off Type")]
        public string TimeOffType { get; set; }
        [Required(ErrorMessage = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date")]
        public DateTime EndDate { get; set; }

        public string Status { get; set; }
        public int TotalDays { get; set; }
        public string EmpNote { get; set; }
        public string MgrNote { get; set; }


    }
}
