using System.Data.SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;
using RegistroDeCompetencia.Models;

//Singleton
namespace RegistroDeCompetencia.Data
{
    public sealed class DbContext
    {
        public static readonly DbContext instance = new DbContext();
        private readonly SQLiteConnection connection = new SQLiteConnection("Data Source=RegistroDeCompetencias.db");

        static DbContext()
        {
        }

        private DbContext()
        {
        }

        // ------------------------ Methods--------------------------------//
        public async Task<IEnumerable<Recinto>> SPGetRecintoNames()
        {
            return await connection.QueryAsync<Recinto>("Select Id, Nombre from Recintos");
        }

        public async Task<Estudiante> SPFindEstudiante(string Id)
        {
            return await connection.QueryFirstOrDefaultAsync<Estudiante>("Select Id from Estudiantes where id = \'" + Id + "\'");
        }

        public async Task SPInsertEstudiante(Estudiante estudiante)
        {
            string query = string.Format(
                "INSERT INTO Estudiantes (Id, Nombre, ApellidoPaterno, ApellidoMaterno, Email, RecintoId)" +
                "VALUES (\'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\', \'{5}\')",
                estudiante.Id, estudiante.Nombre, estudiante.ApellidoPaterno, estudiante.ApellidoMaterno, estudiante.Email, estudiante.RecintoId
            );

            await connection.ExecuteAsync(query);
        }
    }
}