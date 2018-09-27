using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using FlightSystem.Data.Domain;

namespace FlightSystem.Data.Repository
{
    public class AircraftRepository : BaseRepository
    {
        public AircraftRepository(string connectionString) : base (connectionString)
        {
        }

        public IEnumerable<Aircraft> GetAircrafts()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Aircraft>("SELECT * FROM Aircraft");
            }
        }
    }
}
