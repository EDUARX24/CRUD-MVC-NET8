using CrudNet8MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CrudNet8MVC.Datos;
using Microsoft.EntityFrameworkCore;

namespace CrudNet8MVC.Controllers
{
    public class InicioController : Controller
    {
        //private readonly ILogger<InicioController> _logger;

        //crear variable para la base de datos
        private readonly ApplicationDbContext _contexto;

        public InicioController(ApplicationDbContext contexto)
        {
            //_logger = logger;
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Contacto.ToListAsync());
        }

        /*INICIO*/
        //crear metodo CREAR y su vista correspondiente
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        //metodo POST para guardar los datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            //validar si los datos son correctos
            if (ModelState.IsValid)
            {
                //Agregar la fecha y hora de creacion]
                contacto.FechaCreacion = DateTime.Now;

                _contexto.Add(contacto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        /*FIN*/


        /*INICIO-EDITAR*/
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();  
            }
            var contact =  _contexto.Contacto.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

           return  View(contact);
        }

        //metodo para editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            //validar si los datos son correctos
            if (ModelState.IsValid)
            {
                _contexto.Update(contacto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        /*FIN*/

        /*INICIO-DETALLE*/
        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contact = _contexto.Contacto.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }
        //FIN

        //Metodo borrar
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contact = _contexto.Contacto.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var contact = await _contexto.Contacto.FindAsync(id);
            if (contact == null)
            {
                return View();
            }
            //Borrar contacto
            _contexto.Contacto.Remove(contact);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        //Fin

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
