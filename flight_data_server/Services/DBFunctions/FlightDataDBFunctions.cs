using flight_data_server.Database;
using flight_data_server.Models.FlightData;
using flight_data_server.Interface;

namespace flight_data_server.Services.DBFunctions
    {

    public class FlightDataDBFunctions : DatabaseFunctions<FlightData>, IFlightDataDBFunctions
        {

        private readonly FlightDataDBContext _db;
        public FlightDataDBFunctions(FlightDataDBContext db) : base(db)
            {
            this._db = db;
            }
        }
    }
