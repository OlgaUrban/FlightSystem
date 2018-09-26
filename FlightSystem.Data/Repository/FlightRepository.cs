using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using FlightSystem.Data.Domain;

namespace FlightSystem.Data.Repository
{
    public class FlightRepository : BaseRepository
    {
        public FlightRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Flight> GetFlights()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Flight, Aircraft, Airport, Airport, Flight>
                    (@"SELECT * FROM Flight f
                        INNER JOIN Aircraft a ON a.Id = f.AircraftId
                        INNER JOIN Airport a1 ON a1.Id = f.DepartureAirportId
                        INNER JOIN Airport a2 ON a2.Id = f.DestinationAirportId",
                    (f, a, a1, a2) =>
                    {
                        f.Aircraft = a;
                        f.DepartureAirport = a1;
                        f.DestinationAirport = a2;
                        return f;
                    },
                    splitOn: "Id, Id, Id");
            }
        }

        public Flight GetFlightById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.QueryFirst<Flight>("SELECT * FROM Flight f WHERE f.Id = @id", new { id });
            }
        }

        public bool CreateFlight(Flight model)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var insertQuery = @"INSERT INTO Flight ([AircraftId]
                   ,[DepartureAirportId]
                   ,[DepartureDateTime]
                   ,[DestinationAirportId]
                   ,[DestinationDateTime]) 
                VALUES (@AircraftId
                   , @DepartureAirportId
                   , @DepartureDateTime
                   , @DestinationAirportId
                   , @DestinationDateTime)";

                var result = db.Execute(insertQuery, new
                {
                    model.AircraftId,
                    model.DepartureAirportId,
                    model.DepartureDateTime,
                    model.DestinationAirportId,
                    model.DestinationDateTime
                });

                return result > 0;
            }
        }

        public bool UpdateFlight(Flight model)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var insertQuery = @"UPDATE Flight 
                     SET [AircraftId] = @AircraftId,
                         [DepartureAirportId] = @DepartureAirportId,
                         [DepartureDateTime] = @DepartureDateTime,
                         [DestinationAirportId] = @DestinationAirportId,
                         [DestinationDateTime] = @DestinationDateTime 
                 WHERE [Id] = @id";

                var result = db.Execute(insertQuery, new
                {
                    model.AircraftId,
                    model.DepartureAirportId,
                    model.DepartureDateTime,
                    model.DestinationAirportId,
                    model.DestinationDateTime,
                    model.Id
                });

                return result > 0;
            }
        }
    }
}
