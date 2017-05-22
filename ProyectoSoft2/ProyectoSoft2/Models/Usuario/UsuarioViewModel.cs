using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoft2.Models.Usuario
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo de Usuario")]
        public int TipoUsuario { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Fecha de Nacimiento")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Correo Electronico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string IdAspNetUser { get; set; }

        public bool EsEditar { get; set; }
    }
}