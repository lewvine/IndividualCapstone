using CapstoneProject.Data;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    public class SalespersonController : Controller
    {
        private ApplicationDbContext _context;


        public SalespersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SalespersonController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var salesperson = _context.Salespeople
                .Include(s => s.Projects)
                   .ThenInclude(p => p.Customer)
                .Include(s => s.Projects)
                    .ThenInclude(p => p.Grass)
                .Include(s => s.Appointments)
                .Where(s => s.IdentityUserId == userId)
                .FirstOrDefault();
            if (salesperson == null)
            {
                return RedirectToAction("Create");
            }
            return View(salesperson);
        }

        // GET: SalespersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalespersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalespersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Salesperson salesperson)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var email = this.User.FindFirstValue(ClaimTypes.Email);
                salesperson.IdentityUserId = userId;
                salesperson.EMailAddress = email;
                string address = salesperson.StreetAddress 
                                 + ", " 
                                 + salesperson.CityAddress 
                                 + ", " 
                                 + salesperson.StateAddress 
                                 + " " 
                                 + salesperson.ZipAddress;
                salesperson.SetGeocode(address);
                salesperson.Appointments = new List<Appointment>();
                DateTime apptTime = new DateTime();
                apptTime = DateTime.Today;
                for (int days = 1; days <= 5; days++)
                {
                    DateTime today = apptTime.AddDays(days);
                    for (int apptIndex = 0; apptIndex < 4; apptIndex++)
                    {
                        int apptHour = 8 + (apptIndex * 2);
                        Appointment appt = new Appointment
                        {
                            AppointmentStart = today.AddHours(apptHour),
                            AppointmentEnd = today.AddHours(apptHour + 2),
                            IsBooked = false,
                            IsCompleted = false,
                            IsOpen = true,
                            Notes = "This appointment is open",
                            InteractionType = "Open appointment",
                            Project = null,
                            ProjID = null,
                        };
                        salesperson.Appointments.Add(appt);
                        _context.SaveChanges();
                    };
                }
                _context.Salespeople.Add(salesperson);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalespersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalespersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalespersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalespersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
