using CV_creator.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_creator.Database
{
    public class CvDbContext : DbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options) : base(options)
        {

        }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BasicInformation> BasicInformations { get; set; }
        public DbSet<Skills> Skills { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BasicInformation>()
                .HasMany(b => b.Educations)
                .WithOne(e => e.BasicInformation)
                .HasForeignKey(e => e.BasicInformationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BasicInformation>()
                .HasMany(b => b.Jobs)
                .WithOne(j => j.BasicInformation)
                .HasForeignKey(j => j.BasicInformationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkExperience>()
                .HasMany(j => j.Skills)
                .WithOne(sa => sa.Job)
                .HasForeignKey(sa => sa.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.BasicInformation)
                .WithOne(b => b.ResidenceAddress)
                .HasForeignKey<Address>(a => a.BasicInformationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Education)
                .WithOne(e => e.InstitutionAddress)
                .HasForeignKey<Address>(a => a.EducationId);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Job)
                .WithMany(j => j.WorkAddresses)
                .HasForeignKey(a => a.JobId);
        }
    }
}
