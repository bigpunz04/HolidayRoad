using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRV7.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Employee> AllEmployees { get; set; }
        public DbSet<Requisition>AllRequisitions { get; set; }
        public DbSet<ViewModelNewRequisition> EmployeeRequisitionInformation { get; set; }
    }
}
