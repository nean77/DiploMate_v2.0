using DiploMate.Student;
using DiploMate.Thesis;
using DiploMate.ThesisState;
using DiploMate.Tutor;
using DiploMate.User;
using Microsoft.EntityFrameworkCore;
namespace DiploMate.Other;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }
    
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<TutorEntity> Tutors { get; set; }
    public DbSet<ThesisEntity> Theses { get; set; }
    public DbSet<ThesisStateEntity> ThesesStates { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .Property(u => u.Email)
            .IsRequired();
        modelBuilder.Entity<UserEntity>()
            .Property(u => u.FirstName)
            .HasMaxLength(100).IsFixedLength()
            .IsRequired();
        modelBuilder.Entity<UserEntity>()
            .Property(u => u.LastName)
            .HasMaxLength(100).IsFixedLength()
            .IsRequired();
        modelBuilder.Entity<UserEntity>()
            .Property(u => u.PasswordHash)
            .IsRequired();
        
        modelBuilder.Entity<Role>()
            .Property(r => r.Id)
            .ValueGeneratedNever();
        
        modelBuilder.Entity<StudentEntity>()
            .Property(s => s.UserName)
            .HasMaxLength(100).IsFixedLength()
            .IsRequired();
        modelBuilder.Entity<StudentEntity>()
            .Property(s => s.StudentIdxNo)
            .HasMaxLength(8).IsFixedLength()
            .IsRequired();
        modelBuilder.Entity<StudentEntity>()
            .Property(s => s.UserEntityId)
            .IsRequired();
        modelBuilder.Entity<TutorEntity>()
            .Property(s => s.UserEntityId)
            .IsRequired();

        modelBuilder.Entity<ThesisEntity>()
            .Property(t => t.Title)
            .HasMaxLength(500).IsFixedLength()
            .IsRequired();
        modelBuilder.Entity<ThesisEntity>()
            .Property(t => t.StartDate);

        modelBuilder.Entity<ThesisStateEntity>()
            .Property(t => t.MeetingDate)
            .IsRequired();
    }

}