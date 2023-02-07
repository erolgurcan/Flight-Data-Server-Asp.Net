using flight_data_server.Models.Airliner;
using flight_data_server.Models.User;
using Microsoft.EntityFrameworkCore;

namespace flight_data_server.Database
    {
    public class AirlinerDBContext : DbContext
        {
        public AirlinerDBContext(DbContextOptions<AirlinerDBContext> options)
            : base(options) { }


        public DbSet<Airliner> Airliner { get; set; }

        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder
                .Entity<Airliner>()
                .HasData(
                    new Airliner()
                        {
                        Id = 1,
                        AirlinerName = "Turkish Airliner",
                        AirlinerCallSign = "THY"
                        }
                );
            }

        internal void AddAsync()
            {
            throw new NotImplementedException();
            }

        }
    };
