using Microsoft.AspNetCore.Mvc;
using CRUD_ASP_CORE.Datos;
using CRUD_ASP_CORE.Models;

namespace CRUD_ASP_CORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _contactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            //LA VISTAQ MOSTRARA UNA LISTA DE CONTACTOS
            var oLista = _contactoDatos.Listar();
            return View(oLista);
        }
        
        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN LA BD

            if (!ModelState.IsValid)
                return View();


            var respuesta = _contactoDatos.Guardar(oContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdContacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oContacto = _contactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN LA BD

            if (!ModelState.IsValid)
                return View();


            var respuesta = _contactoDatos.Editar(oContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdContacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oContacto = _contactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {

            var respuesta = _contactoDatos.Eliminar(oContacto.IdContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
