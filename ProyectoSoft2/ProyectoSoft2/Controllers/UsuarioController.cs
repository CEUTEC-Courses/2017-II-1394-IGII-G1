using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProyectoSoft2.DB;
using ProyectoSoft2.Models;
using ProyectoSoft2.Models.Base;
using ProyectoSoft2.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSoft2.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarUsuario()
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
                    TipoUsuario = x.AspNetUsers.AspNetRoles.Any()? x.AspNetUsers.AspNetRoles.FirstOrDefault().Name :""
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
                ViewBag.ListaTipoUsuario = context.AspNetRoles.Select(x => new SelectListItem { Value = x.Id, Text = x.Name }).ToList();
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CrearUsuario(UsuarioViewModel model)
        {
            try {
                using (var context = new courageproEntities())
                {
                    var user = new ApplicationUser { UserName = model.UserName.Trim(), Email = model.Email.Trim() };
                    var result = await UserManager.CreateAsync(user, model.Password.Trim());
                    if (result.Succeeded)
                    {
                        await UserManager.AddToRoleAsync(user.Id, context.AspNetRoles.Find(model.RoleUsuario).Name);

                        var test = context.Usuarios.Add(new Usuarios
                        {
                            Nombre = model.FirstName.Trim(),
                            Apellido = model.LastName.Trim(),
                            FechaNacimiento = model.BirthDate,
                            IdAspNetUser = user.Id,
                        });

                        var resultado = context.SaveChanges() > 0;
                        return Json(new MensajeRespuestaViewModel
                        {
                            Titulo = "Crear Usuario",
                            Mensaje = resultado ? "Se creo Satisfactoriamente" : "Error al crear el Usuario",
                            Estado = resultado
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new MensajeRespuestaViewModel
                        {
                            Titulo = "Crear Usuario",
                            Mensaje = result.Errors.FirstOrDefault(),
                            Estado = result.Succeeded
                        }, JsonRequestBehavior.AllowGet);

                    }
                }
            }
            catch (Exception e)
            {
                return Json(new MensajeRespuestaViewModel
                {
                    Titulo = "Crear Usuario",
                    Mensaje = e.Message,
                    Estado = false
                }, JsonRequestBehavior.AllowGet);
            }
  
        }



        [HttpGet]
        public ActionResult EditarInfoUsuario(int Id)
        {
            using (var context = new courageproEntities())
            {
                var usuario = context.Usuarios.Find(Id);              
                return PartialView(new UsuarioViewModel {
                    FirstName = usuario.Nombre,
                    LastName = usuario.Apellido,
                    BirthDate = usuario.FechaNacimiento
                });
            }
        }

        [HttpGet]
        public ActionResult EditarCuentaUsuario(int Id)
        {
            using (var context = new courageproEntities())
            {
                ViewBag.ListaTipoUsuario = context.AspNetRoles.Select(x => new SelectListItem { Value = x.Id, Text = x.Name }).ToList();
                var usuario = context.Usuarios.Find(Id);
                var user =  UserManager.FindByIdAsync(usuario.IdAspNetUser);
                return PartialView(new UsuarioViewModel
                {
                    UserName = user.Result.UserName,
                    Email = user.Result.Email,      
                });
            }
        }

        [HttpGet]
        public ActionResult ResetContrasena(int Id)
        {
            using (var context = new courageproEntities())
            {               
                return PartialView(new CambiarContrasenaViewModel { IdUser = Id});
            }
        }


        [HttpPost]
        public async Task<ActionResult> ResetContrasena(CambiarContrasenaViewModel model)
        {
            using (var context = new courageproEntities())
            {
                var User = context.Usuarios.Find(model.IdUser);
                string code = await UserManager.GeneratePasswordResetTokenAsync(User.IdAspNetUser);
                var result = await UserManager.ResetPasswordAsync(User.IdAspNetUser, code, model.NewPassword);
         
                    return Json(new MensajeRespuestaViewModel
                    {
                        Titulo = "Cambiar Contrasena",
                        Mensaje = result.Succeeded ? "Se cambio Satisfactoriamente" : "Error al cambiar la contrasena",
                        Estado = result.Succeeded
                    }, JsonRequestBehavior.AllowGet);                  
            }
        }


    }
}