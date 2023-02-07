using flight_data_server.Database;
using flight_data_server.Interface;
using flight_data_server.Models;
using flight_data_server.Models.FlightData;
using System.Linq.Expressions;

namespace flight_data_server.Services.DBFunctions
{


    public class FlightDataDBFunctions : DatabaseFunctions<FlightData>
    {

        private readonly AirlinerDBContext _db;
        public FlightDataDBFunctions(AirlinerDBContext db) : base(db)
        {
            this._db = db;
        }
    }
}
