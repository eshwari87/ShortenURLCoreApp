// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShortenURLCoreApp.Models;

#nullable disable

namespace ShortenURLCoreApp.Migrations
{
    [DbContext(typeof(UrlDbContext))]
    partial class UrlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("ShortenURLCoreApp.Models.UrlModel", b =>
                {
                    b.Property<int>("urlID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DomainName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortenUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("urlID");

                    b.ToTable("Url");
                });
#pragma warning restore 612, 618
        }
    }
}
