using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace flight_data_server.Models.Airliner
    {
    public class AirlinerCreate
        {

        [Required]
        public int Id { get; set; }

        [Required]
        public string? AirlinerName { get; set; }

        [Required]
        public string? AirlinerCallSign { get; set; }
        }
    }
