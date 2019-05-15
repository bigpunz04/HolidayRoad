using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRV7.Models
{
    public class ViewModelNewRequisition
    {
        [Key]
        public int ViewModelNewRequisitionId { get; set; }
        public Employee VMNREmp { get; set; }
        public Requisition VMNRReq { get; set; }
    }
}
