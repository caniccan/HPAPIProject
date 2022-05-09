using HP.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.DataAccess.Data
{
    public class HPDbContext : DbContext
    {
        // Most İmportent Class for Entity Framework and Database connection...
        public DbSet<Character> Characters { get; set; }
        public DbSet<Category> Categories { get; set; }

        public HPDbContext(DbContextOptions<HPDbContext>options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Character>().HasOne(c => c.Category)
                                            .WithMany(p => p.Characters)
                                            .HasForeignKey(c => c.CategoryId)
                                            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Bright Side" },
                new Category() { Id = 2, Name = "Dark Side" });

            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    CharacterId = 1,
                    BirthYear = 1999,
                    EyeColor = "Brown",
                    Gender = "Male",
                    HairColor = "Brown",
                    HaveNose = true,
                    Pet = "Cat",
                    Height = 193,
                    Mass = 90,
                    Name = "Can",
                    Surname = "İçcan",
                    SkinColor = "White",
                    Wands = "Dont Have",
                    Id = 1
                },
                new Character
                {
                    CharacterId = 2,
                    BirthYear = 1980,
                    EyeColor = "Bright green",
                    Gender = "Male",
                    HairColor = "Jet-black",
                    HaveNose = true,
                    Pet = "Snowy owl",
                    Height = 180,
                    Mass = 67,
                    Name = "Harry James",
                    Surname = "Potter",
                    SkinColor = "Light",
                    Wands = "Harry Potter's Wand, Blackthorn Wand, Draco Malfoy's Wand, Elder Wand",
                    Id = 2

                }

                );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // you can delete this part bu bölümü silebilirsin.
           // optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;");
        }
    }
}
