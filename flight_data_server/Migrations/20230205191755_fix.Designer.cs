// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using flight_data_server.Database;

#nullable disable

namespace flightdataserver.Migrations
{
    [DbContext(typeof(AirlinerDBContext))]
    [Migration("20230205191755_fix")]
    partial class fix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("flight_data_server.Models.Airliner.Airliner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AirlinerCallSign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AirlinerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airliner");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AirlinerCallSign = "THY",
                            AirlinerName = "Turkish Airliner"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
