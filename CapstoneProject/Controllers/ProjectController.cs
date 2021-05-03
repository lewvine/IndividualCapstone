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
    public class ProjectController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ProjectController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProjectController/Details/5
        public ActionResult Details(Project project)
        {
            project.Appointments = _context.Appointments.Where(a => a.ProjID == project.id).ToList();
            project.Salesperson = _context.Salespeople.Include("Appointments").Where(s => s.id == project.SalesID).FirstOrDefault();
            project.Customer = _context.Customers.Where(c => c.id == project.CustID).FirstOrDefault();
            project.Grass = _context.Grasses.Where(g => g.id == project.GrassID).FirstOrDefault();
            _context.Projects.Update(project);
            _context.SaveChanges();
            ViewBag.MapUrl = $"https://www.google.com/maps/embed/v1/place?key=" + Utilities.APIs.MapsKey + "&q=" + project.LatAddress.ToString() + "," + project.LongAddress.ToString();

            //Adding an appointment for testing;
            return View(project);
        }

        public ActionResult ConfirmAppointment(int apptId, int id)
        {
            Project project = _context.Projects.Where(p => p.id == id).FirstOrDefault();
            project.Salesperson = _context.Salespeople.Where(s => s.id == project.SalesID).FirstOrDefault();
            project.Customer = _context.Customers.Where(c => c.id == project.CustID).FirstOrDefault();
            Appointment appt = _context.Appointments.Where(a => a.id == apptId).FirstOrDefault();
            appt.IsBooked = true;
            appt.IsOpen = false;
            appt.ProjID = project.id;
            appt.id = apptId;
            project.Salesperson.Appointments.Add(appt);
            _context.SaveChanges();
            string body = $"Your appointment with {project.Salesperson.FirstName} on {appt.AppointmentStart.DayOfWeek} , {appt.AppointmentStart.ToString("MMMM dd")} at {project.Appointments.Last().AppointmentStart.ToString("t")} has been confirmed.  If you need to change your appointmnet, please login to our website.";
            project.SendText(body);
            return RedirectToAction("Details", project);
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();
            if(customer == null)
            {
                return RedirectToAction("Create", "Customer");
            }
            project.Customer = customer;
            project.CustID = customer.id;
            project.Appointments = new List<Appointment>();
            project.IsSold = false;
            project.StreetAddress = customer.StreetAddress;
            project.CityAddress = customer.CityAddress;
            project.StateAddress = customer.StateAddress;
            project.ZipAddress = customer.ZipAddress;
            project.Grass = _context.Grasses.Where(g => g.id == project.GrassID).FirstOrDefault();
            project.Name = project.StreetAddress + "-" + project.Grass.Name + "-" + project.SquareFootage.ToString();
            if (project.IsProjectAreaCleared == false)
            {
                project.Cost = project.SquareFootage * (project.Grass.Cost + 1);
                project.Description = $"This is a {project.Grass} project of {project.SquareFootage}, located at {project.StreetAddress}, {project.CityAddress}, {project.StreetAddress} {project.ZipAddress}  The area needs to be cleared."
                    + $"  The total project cost is expected to be {project.Cost}.";
            }
            else
            {
                project.Cost = project.SquareFootage * project.Grass.Cost;
                project.Description = $"This is a {project.Grass.Name} project of {project.SquareFootage}, located at {project.StreetAddress}, {project.CityAddress}, {project.StreetAddress} {project.ZipAddress}.  The area is ready for grass."
                    + $"  The total project cost is expected to be {project.Cost}.";
            }
            string address = project.StreetAddress
                 + ", "
                 + project.CityAddress
                 + ", "
                 + project.StateAddress
                 + " "
                 + project.ZipAddress;
            project.SetGeocode(address);
            var salesperson = _context.Salespeople.Where(s => s.ZipAddress == project.ZipAddress).FirstOrDefault();
            if (salesperson == null)
            {
                List<Salesperson> salespeople = _context.Salespeople.Include("Appointments").ToList();
                project.SalesID = salespeople[0].id;
                project.Salesperson = salespeople[0];
            }
            else
            {
                project.SalesID = salesperson.id;
                project.Salesperson = salesperson;
            }
            _context.Projects.Add(project);
            _context.SaveChanges();
            return RedirectToAction("Details", project);
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
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

        // GET: ProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectController/Delete/5
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
