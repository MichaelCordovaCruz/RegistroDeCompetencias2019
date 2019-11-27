using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using RegistroDeCompetencia2019.Models;

namespace RegistroDeCompetencia2019.ViewModels
{
    public class CreateHomeVM
    {
        public Estudiante Estudiante { get; set; }
        public IEnumerable<Recinto> Recintos { get; set; }
    }
}
