using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using FlightSystem.Data.Domain;

namespace FlightSystem.Data.Repository
{
    public class AirportRepository : BaseRepository
    {
        public AirportRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Airport> GetAirportSelectList()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Airport>("SELECT * FROM Airport");
            }
        }
    }
}
