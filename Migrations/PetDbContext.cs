using midterm_project.Models;
using Microsoft.EntityFrameworkCore;

namespace midterm_project.Migrations;

public class PetDbContext : DbContext {

    public DbSet<Pet> Pet { get; set; }

    public PetDbContext(DbContextOptions<PetDbContext> options) : base(options) {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pet>(entity => {
            entity.HasKey(e => e.PetId);
            entity.Property(e => e.PetName);
            entity.Property(e => e.PetImgUrl);
            entity.Property(e => e.PetDescription);
            entity.Property(e => e.PetBreed);
            entity.Property(e => e.PetAge);

            // To convert enum value to string in the database (https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations)
            entity.Property(e => e.PetGender).HasConversion<string>();
        });
    }
}