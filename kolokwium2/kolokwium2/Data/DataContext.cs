using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Data;

public class DataContext : DbContext
{
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }

    protected DataContext()
    {
    }

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item()
            {
                Id = 1,
                Name = "adidas",
                Weight = 12
            },
            new Item()
            {
                Id = 2,
                Name = "nike",
                Weight = 22
            }
        });

        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title()
            {
                Id = 1,
                Name = "title1"
            },
            new Title()
            {
                Id = 2,
                Name = "title2"
            }
        });

        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character()
            {
                id = 1,
                FirstName = "Dominik",
                LastName = "Kowalski",
                CurrentWeight = 50,
                MaxWeight = 70
            },
            new Character()
            {
                id = 2,
                FirstName = "tomek",
                LastName = "Kowalski",
                CurrentWeight = 40,
                MaxWeight = 170
            }
        });

        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>
        {
            new CharacterTitle()
            {
                CharacterId = 1,
                TitleId = 2,
                AcquiredAt = DateTime.Now
            },
            new CharacterTitle()
            {
                CharacterId = 2,
                TitleId = 2,
                AcquiredAt = DateTime.Now
            }
        });
        
        
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack()
            {
                CharacterId = 1,
                ItemId = 1,
                Amount = 3
                
            },
            new Backpack()
            {
                CharacterId = 2,
                ItemId = 1,
                Amount = 1
                
            }
        });
    }
}