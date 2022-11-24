using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RollNRunWeb.Models
{
    public class TarjetaViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public int usuario { get; set; }

        [Display(Prompt = "Nombre de titular de la tarjeta", Description = "Nombre de titular de la tarjeta", Name = "Titular")]
        [Required(ErrorMessage = "Debe indicar un titular de la tarjeta")]
        [StringLength(maximumLength: 200, ErrorMessage = "El titular no puede tener más de 200 caracteres")]
        public string titular { get; set; }

        [Display(Prompt = "Número de la tarjeta", Description = "Número de la tarjeta", Name = "Número")]
        [Required(ErrorMessage = "Debe introducir el número de la tarjeta")]
        [StringLength(maximumLength: 16, MinimumLength = 16, ErrorMessage = "El número de la tarjeta debe tener 16 caracteres")]
        public string numero { get; set; }

        [Display(Prompt = "CVV de la tarjeta", Description = "CVV de la tarjeta", Name = "CVV")]
        [Required(ErrorMessage = "Debe introducir el CVV de la tarjeta")]
        [StringLength(maximumLength: 4, MinimumLength = 3, ErrorMessage = "El CVV de la tarjeta debe tener 3 o 4 caracteres")]
        public string cvv { get; set; }


        [Display(Prompt = "Fecha de caducidad", Description = "Fecha de caducidad", Name = "FechaCad ")]
        [Required(ErrorMessage = "Debe indicar una fecha")]
        [DataType(DataType.DateTime, ErrorMessage = "Debe introducir una fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaCad { get; set; }
    }
}