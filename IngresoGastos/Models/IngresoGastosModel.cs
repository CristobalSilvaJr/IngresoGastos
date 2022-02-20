using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngresoGastos.Models
{
    public class IngresoGastosModel
    {
        [Key]//Asignamos como primary key 
        public int Id { get; set; }
        [Required]//Le asignamos como requerido, es decir, no puede quedar vacio.
        [StringLength (60,MinimumLength = 3)] //Le asignamos el maximo de 60 caracteres con un minimo de 3.
        public string Descripcion{ get; set; }
        [Required]//Le asignamos como requerido, es decir, no puede quedar vacio.
        [Display(Name ="Tipo")]
        public bool EsIngreso{ get; set; }
        [Required]//Le asignamos como requerido, es decir, no puede quedar vacio.
        public double Valor{ get; set; }
        [Display(Name ="Fecha de ingreso")]
        public DateTime FechaIngreso{ get; set; }
    }
}