using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroDeCompetencia2019.Models
{
    public class Estudiante
    {
        //Keys
        [Key]
        [DataType(DataType.Text)]
        [Display(Name = "Numero De Estudiante")]
        public string Id { get; set; }

        [ForeignKey("Recinto")]
        [DataType(DataType.Text)]
        [Display(Name = "Recinto Id")]
        [Required(ErrorMessage="Recinto Id es Requirido")]
        public int RecintoId { get; set; }

        //Attributes
        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage="Nombre es Requirido")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage="Apellido Paterno es Requirido")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage="Apellido Materno es Requirido")]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage="Email es Requirido")]
        public string Email { get; set; }


        //Relations
        public virtual Recinto Recinto { get; set; } 
        
    }
}