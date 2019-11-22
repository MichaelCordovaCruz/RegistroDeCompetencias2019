using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using RegistroDeCompetencia2019.Models;
using RegistroDeCompetencia2019.Data;
using RegistroDeCompetencia2019.ViewModels;

namespace RegistroDeCompetencia2019.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(new CreateHomeVM{ 
                Recintos = await _context.Recintos.ToListAsync()
            });
        }

        public async Task<IActionResult> Create()
        {
            return View(new CreateHomeVM{ 
                Recintos = await _context.Recintos.ToListAsync()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Estudiante")] CreateHomeVM homeVM)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Estudiantes.Add(homeVM.Estudiante);
                    _context.SaveChanges();
                }
                catch(DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
                }
            }
            else
            {
                
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
