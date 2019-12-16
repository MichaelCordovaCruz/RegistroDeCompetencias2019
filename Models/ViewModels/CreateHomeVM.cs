using System.Collections.Generic;
using RegistroDeCompetencia.Models;

namespace RegistroDeCompetencia.ViewModels
{
    public class CreateHomeVM
    {
        public Estudiante Estudiante { get; set; }
        public IEnumerable<Recinto> Recintos { get; set; }
    }
}
