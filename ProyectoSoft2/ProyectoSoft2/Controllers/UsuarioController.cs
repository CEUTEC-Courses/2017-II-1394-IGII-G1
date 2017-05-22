using ProyectoSoft2.DB;
using ProyectoSoft2.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSoft2.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
                return View();                
        }

        [HttpGet]
        public ActionResult ListarUsuarios()
        {
            using (var context = new courageproEntities())
            {
                var listaUsuarios = context.Usuarios.Select(x => new ListaUsuarioViewModel
                {
                    Id = x.IdUsuario,
                    FirstName = x.Nombre,
                    LastName = x.Apellido,
                    UserName = x.AspNetUsers.UserName,
                    BirthDate = x.FechaNacimiento,
                    Email = x.AspNetUsers.Email,
                    Estado = true,
                    TipoUsuario = x.TipoUsuario.Descripcion,
                }).ToList();
                var jsonResult = Json(listaUsuarios, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = Int32.MaxValue;
                return jsonResult;
            }
        }


        [HttpGet]
        public ActionResult CrearUsuario()
        {
            using (var context = new courageproEntities())
            {
                ViewBag.ListaTipoUsuario = context.TipoUsuario.Select(x => new SelectListItem { Value = x.IdTipoUsuario.ToString(), Text = x.Descripcion });
                 return View();
            }
        }

        [HttpPost]
        public ActionResult CrearUsuario(UsuarioViewModel model)
        {
            using (var context = new courageproEntities())
            {
 
                return View();
            }
        }


















    }
}