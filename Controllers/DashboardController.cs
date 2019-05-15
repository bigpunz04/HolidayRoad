using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRV7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRV7.Controllers
{
    public class DashboardController : Controller
    {

        private readonly DatabaseContext _databaseContext;

        public DashboardController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Dashboard()
        {
            ViewModelDashboard Listing = new ViewModelDashboard();
            Listing.EmployeesModel = await _databaseContext.AllEmployees.ToListAsync();
            Listing.RequisitionsModel = await _databaseContext.AllRequisitions.ToListAsync();
            return View(Listing);
        }

        public async Task<IActionResult> ViewDetails(int id)
        {
            Employee ThisEmployee = await _databaseContext.AllEmployees.FindAsync(id);
            return View(ThisEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployeeDetails(int id)
        {
            Employee ThisEmployee = await _databaseContext.AllEmployees.FindAsync(id);
            return View(ThisEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployeeDetailsConfirmation(Employee emp)
        {
            
            _databaseContext.AllEmployees.Update(emp);
            await _databaseContext.SaveChangesAsync();
            return RedirectToAction(nameof(Dashboard));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            Employee ThisEmployee = await _databaseContext.AllEmployees.FindAsync(id);
            return View(ThisEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmployeeConfirmation(Employee emp)
        {
            
            _databaseContext.AllEmployees.Remove(emp);
            await _databaseContext.SaveChangesAsync();
            return RedirectToAction(nameof(Dashboard));
        }


        public async Task<IActionResult> ViewRequisitionDetails(int id)
        {
            Requisition ThisRequisition = await _databaseContext.AllRequisitions.FindAsync(id);
            Employee ThisEmployee = await _databaseContext.AllEmployees.FindAsync(ThisRequisition.EmployeeFK);
            ViewBag.First = ThisEmployee.FirstName;
            ViewBag.Last = ThisEmployee.LastName;
            ViewBag.EmploymentType = ThisEmployee.EmploymentType;
            ViewBag.VacationDays = ThisEmployee.VacationDays;
            ViewBag.SickDays = ThisEmployee.SickDays;
            ViewBag.BereavementDays = ThisEmployee.BereavementDays;

            return View(ThisRequisition);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRequisition(int? id)
        {
            Requisition ThisRequisition = await _databaseContext.AllRequisitions.FindAsync(id);
            Employee ThisEmployee = await _databaseContext.AllEmployees.FindAsync(ThisRequisition.EmployeeFK);
            ViewBag.FullName = ThisEmployee.FirstName + " " + ThisEmployee.LastName;

            return View(ThisRequisition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRequisitionConfirmed(int id)
        {
           
            var thisRequisition = await _databaseContext.AllRequisitions.FindAsync(id);
          
            _databaseContext.AllRequisitions.Remove(thisRequisition);
            await _databaseContext.SaveChangesAsync();
            return RedirectToAction(nameof(Dashboard));
        }
    }
}
