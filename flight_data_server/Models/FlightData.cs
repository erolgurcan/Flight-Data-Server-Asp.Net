using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flight_data_server.Models
    {
    public class FlightData
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime LoggingTime { get; set; }

        public double IAS { get; set; }

        public double CAS { get; set; }
        }
    }
