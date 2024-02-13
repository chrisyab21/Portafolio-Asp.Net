using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;
using Portafolio.Servicios;
using Portafolio.Interfaces;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repoProyectos;
        private readonly IConfiguration config;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repoProyectos, IConfiguration config, IServicioEmail servicioEmail)
        {
            _logger = logger;
            this.repoProyectos = repoProyectos;
            this.config = config;
            this.servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            //persona Persona1 = new persona()
            //{
            //    Edad = 24,
            //    Nombre = "christian"

            //};
            //

            var apellido = config.GetValue<String>("Apellido");

            _logger.LogTrace("Este es un mensaje de trace");
            _logger.LogCritical("Este es un mensaje de critical proveniente de " + apellido);


            List<Proyecto> ProyectosX = repoProyectos.ObtenerProyectos().Take(3).ToList();



            HomeIndexViewModel modelo = new HomeIndexViewModel() {

                Proyectos = ProyectosX

            };

            return View("Index",modelo);
        }

        public IActionResult Privacy()
        {
            return View();
        }



        public IActionResult Proyectos()
        {
            List<Proyecto> proyectos = repoProyectos.ObtenerProyectos();

            return View("_ListadoProyectos",proyectos);
        }


        public IActionResult Contacto()
        {
            

            return View("Contacto");
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel )
        {

            await servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }


        public IActionResult Gracias()
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