using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRV7.Models
{
    public class ViewModelDashboard
    {
        public IEnumerable<Employee> EmployeesModel { get; set; }
        public IEnumerable<Requisition> RequisitionsModel { get; set; }
    }
}
