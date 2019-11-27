using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RegistroDeCompetencia2019.Models
{
    public class Recinto
    {
        //Keys
        [Key]
        public int Id { get; set; }

        //Attributes
        public string Nombre { get; set; }

        //Relations
        public ICollection<Estudiante> Estudiantes { get; set; }
    }
}
