using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flight_data_server.Models.Airliner
    {
    public class Airliner
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? AirlinerName { get; set; }
        public string AirlinerCallSign { get; set; }

        }
    }
