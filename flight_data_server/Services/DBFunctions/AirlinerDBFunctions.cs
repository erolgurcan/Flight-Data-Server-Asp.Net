using flight_data_server.Database;
using flight_data_server.Interface;
using flight_data_server.Models.Airliner;
using System.Linq.Expressions;

namespace flight_data_server.Services.DBFunctions
    {
    public class AirlinerDBFunctions : DatabaseFunctions<Airliner>, IAirlinerDBFunctions
        {

        private readonly AirlinerDBContext _db;

        public AirlinerDBFunctions(AirlinerDBContext db) : base(db)
            {
            this._db = db;
            }



        }
    }
