using System.Linq;
using System.Data.SQLite;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegistroDeCompetencia.Models;
using Dapper;

namespace RegistroDeCompetencia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Estudiante> Get()
        {
            Estudiante[] estudiantes;
            string query = "Select * from Estudiantes, Recintos where Recintos.Id = RecintoId";

            using(var connection = new SQLiteConnection("Data Source=RegistroDeCompetencias.db"))
            {
                estudiantes = connection.Query<Estudiante, Recinto, Estudiante>(query,
                (Estudiante, Recinto) =>
                {
                    Estudiante.Recinto = Recinto;
                    return Estudiante;
                },
                splitOn: "Id")
                .Distinct()
                .ToArray();
            }

            return estudiantes;
        }
    }
}
