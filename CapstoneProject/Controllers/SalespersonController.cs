using CapstoneProject.Data;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var salesperson = _context.salespeople.Where(s => s.IdentityUserId == userId).FirstOrDefault();

            if (salesperson == null)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                var projects = _context.projects.Where(p => p.Salesperson.ID == salesperson.ID).ToList();

                if (projects.Count() > 0)
                {
                    ViewBag.projects = projects.ToList();
                    return View(salesperson);
                }
                else
                {
                    return View(salesperson);
                }
            }
            return View();
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
                _context.salespeople.Add(salesperson);
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
