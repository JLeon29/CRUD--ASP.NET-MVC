using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LUCKYSAC.Models.VieModels
{
    public class ClientesViewModell
    {
        public int IdCliente { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name ="Nombres")]
        public string Nombres { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Apellidos")]
        public string  Apellidos { get; set; }
        [Required]
        [StringLength(8)]
        [Display(Name = "DNI")]
        public string DNI { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name ="Telefono")]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name ="Correo Electronico")]
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}