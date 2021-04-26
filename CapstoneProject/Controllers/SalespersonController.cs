using CapstoneProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Create(IFormCollection collection)
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
