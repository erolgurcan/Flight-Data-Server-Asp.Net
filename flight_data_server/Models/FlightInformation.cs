using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flight_data_server.Models
{
    public class FlightInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public String? FlightNo { get; set; }
        public String? Destination { get; set; }
        public String? Arrival { get; set; }
        [Required]
        [ForeignKey("AirlinerId")]
        public int AirlinerId { get; set; }
    }
}
