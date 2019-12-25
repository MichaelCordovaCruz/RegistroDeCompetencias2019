using System.Linq;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegistroDeCompetencia.Models;
using RegistroDeCompetencia.Data;
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
        public async Task<IEnumerable<Estudiante>> Get()
        {
            return await DbContext.instance.SPGetStudents();
        }
    }
}
