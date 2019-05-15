using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRV7.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRV7.Controllers
{
    public class RequisitionController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public RequisitionController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<IActionResult> NewRequisition(int id)
        {
            //GET EMPLOYEE INFORMATION 
            Employee ThisEmployee = await _databaseContext.AllEmployees.FindAsync(id);
            ViewBag.Name = ThisEmployee.FirstName + " " + ThisEmployee.LastName;
            ViewBag.EmployeeId = ThisEmployee.EmployeeId;
            ViewBag.EmploymentType = ThisEmployee.EmploymentType;
            
            //SEND DATE TO VIEW
            ViewBag.Now = DateTime.Now;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewRequisition(Requisition ThisRequisition)
        {
            if (ModelState.IsValid)
            {
                _databaseContext.Add(ThisRequisition);
                await _databaseContext.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Dashboard");
            }
            
            return View(ThisRequisition);
        }

        [HttpGet]
        public async Task<IActionResult> ApproveDenyRequisition(int id)
        {
            var ThisReq = await _databaseContext.AllRequisitions.FindAsync(id);
            var ThisEmployee = await _databaseContext.AllEmployees.FindAsync(ThisReq.EmployeeFK);
            ViewBag.First = ThisEmployee.FirstName;
            ViewBag.Last = ThisEmployee.LastName;
            ViewBag.EmploymentType = ThisEmployee.EmploymentType;
            ViewBag.VacationDays = ThisEmployee.VacationDays;
            ViewBag.SickDays = ThisEmployee.SickDays;
            ViewBag.BereavementDays = ThisEmployee.BereavementDays;

            return View(ThisReq);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveDenyRequisitionConfirmed([FromForm] Requisition CompletedRequisition)
        {
            if (ModelState.IsValid)
            {
                if(CompletedRequisition.Status == "Approved")
                { 
                Employee ThisEmployee = await _databaseContext.AllEmployees.FindAsync(CompletedRequisition.EmployeeFK);
                UpdateTimeOffType(ThisEmployee, CompletedRequisition);
                }

                _databaseContext.AllRequisitions.Update(CompletedRequisition);
                await _databaseContext.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Dashboard");
            }

            return View(CompletedRequisition);
        }

        public void UpdateTimeOffType(Employee emp, Requisition req)
        {
            if(req.TimeOffType == "Vacation")
            {
                emp.VacationDays = emp.VacationDays - req.TotalDays;
            }
            else if(req.TimeOffType == "Sick")
            {
                emp.SickDays = emp.SickDays - req.TotalDays;
            }
            else
            {
                emp.BereavementDays = emp.BereavementDays - req.TotalDays;
            }
        }
    }
}