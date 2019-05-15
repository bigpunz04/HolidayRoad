using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRV7.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRV7.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public EmployeeController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult NewEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewEmployee(Employee NewEmployee)
        {
            if (ModelState.IsValid)
            {
                _databaseContext.Add(NewEmployee);
                await _databaseContext.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Dashboard");
            }
            return View(NewEmployee);
        }
    }
}