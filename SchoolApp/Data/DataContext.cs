global using Microsoft.EntityFrameworkCore;
using SchoolApp.Entities;

namespace SchoolApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Pupil> Pupils { get; set; } = null!;
        public DbSet<TeacherPupil> TeacherPupils { get; set; } = null!;


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SchoolDb;Trusted_Connection=True;");
        }

        // Defines Relationships between Teacher and Pupil entities through TeacherPupil entity. Creates many-to-many relationship
        // between them, where one teacher can have many pupils and pupil can have many teacers
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherPupil>()
                .HasKey(tp => tp.TeacherPupilID);

            modelBuilder.Entity<TeacherPupil>()
                .HasOne(tp => tp.Teacher)
                .WithMany(t => t.TeacherPupils)
                .HasForeignKey(tp => tp.TeacherID);

            modelBuilder.Entity<TeacherPupil>()
                .HasOne(tp => tp.Pupil)
                .WithMany(p => p.TeacherPupils)
                .HasForeignKey(tp => tp.PupilID);
        }

    }
}
