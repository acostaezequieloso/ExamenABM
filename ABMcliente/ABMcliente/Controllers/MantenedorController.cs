using Microsoft.AspNetCore.Mvc;
using ABMcliente.Datos;
using ABMcliente.Models;

namespace ABMcliente.Controllers
{
    public class MantenedorController : Controller
    {   

        Cliente _Cliente = new Cliente();

        public IActionResult Listar()
        {
            //LA VISTA MOSTRARÁ UNA LISTA DE CLIENTES

            var oLista = _Cliente.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA 
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ClienteModel oCliente)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _Cliente.Guardar(oCliente);

            if(respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        
            
        }
        public IActionResult Editar(int Id_cliente)
        {
            //METODO DE EDITAR
            var oCliente = _Cliente.Obtener(Id_cliente);

            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel oCliente)
        {
            //METODO RECIBE EL OBJETO EDITAR EN BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _Cliente.Editar(oCliente);

            if (respuesta)
                return RedirectToAction("Lista");
            else
                return View();


        }
        public IActionResult Eliminar(int Id_cliente)
        {
            //ELIMINAR
            var oCliente = _Cliente.Obtener(Id_cliente);

            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Eliminar(ClienteModel oCliente)
        {
            //ELIMINAR EN BD


            var respuesta = _Cliente.Eliminar(oCliente.Id_cliente);

            if (respuesta)
                return RedirectToAction("Lista");
            else
                return View();


        }
    }


}
 

