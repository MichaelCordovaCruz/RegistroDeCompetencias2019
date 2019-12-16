using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegistroDeCompetencia.Data;
using RegistroDeCompetencia.Models;
using RegistroDeCompetencia.ViewModels;

namespace RegistroDeCompetencia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(new CreateHomeVM{ 
                Recintos = await DbContext.instance.SPGetRecintoNames()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Estudiante")] CreateHomeVM homeVM)
        {
            if(ModelState.IsValid)
            {
                if(await DbContext.instance.SPFindEstudiante(homeVM.Estudiante.Id) == null)
                {
                    try
                    {
                        await DbContext.instance.SPInsertEstudiante(homeVM.Estudiante);
                        return RedirectToAction("Index");
                    }
                    catch(Exception e)
                    {
                        ModelState.AddModelError("", "Error, información entrada no pudo ser guardada. "
                        + "Contacte a el administrador poder ayudarle.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Ya este número de estudiante esta registrado");
                } 

            }
            else
            {
                ModelState.AddModelError("", "La información entrada no es valida. Por favor, inténtelo de nuevo");   
            }

            homeVM.Recintos = await DbContext.instance.SPGetRecintoNames();
            return View(homeVM);
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
