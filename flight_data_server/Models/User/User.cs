using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flight_data_server.Models.User
    {
    public class User
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }

        }
    }
