using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RollNRunWeb.Models
{
    public class UsuarioViewModel : RegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Alias", Description = "Apodo del usuario", Name = "Alias ")]
        [Required(ErrorMessage = "Debe indicar un alias para el usuario")]
        [StringLength(maximumLength: 20, ErrorMessage = "El alias no puede tener más de 20 caracteres")]
        public string alias { get; set; }

        [Display(Prompt = "Nombre del usuario", Description = "Nombre del usuario", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar el nombre del usuario")]
        public string nombre { get; set; }

        [Display(Prompt = "Apellidos del usuario", Description = "Apellidos del usuario", Name = "Apellidos")]
        [Required(ErrorMessage = "Debe indicar al menos un apellido para el usuario")]
        public string apellidos { get; set; }

        [Display(Prompt = "Email del usuario", Description = "Email del usuario", Name = "Email")]
        [Required(ErrorMessage = "Debe indicar un email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "No se ha introducido correctamente el email")]
        public string email { get; set; }


        [Display(Prompt = "Telefono del usuario", Description = "Telefono del usuario", Name = "Telefono ")]
        [Required(ErrorMessage = "Debe indicar un telefono de usuario")]
        public string telefono { get; set; }
    }
}