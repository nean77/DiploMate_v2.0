using Microsoft.EntityFrameworkCore;
namespace DiploMate.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<Thesis> Theses { get; set; }
    public DbSet<ThesisState> ThesesStates { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .HasMaxLength(100).IsFixedLength()
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.LastName)
            .HasMaxLength(100).IsFixedLength()
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.PasswordHash)
            .IsRequired();
        
        modelBuilder.Entity<Role>()
            .Property(r => r.Id)
            .ValueGeneratedNever();
        
        modelBuilder.Entity<Student>()
            .Property(s => s.UserName)
            .HasMaxLength(100).IsFixedLength()
            .IsRequired();
        modelBuilder.Entity<Student>()
            .Property(s => s.StudentIdxNo)
            .HasMaxLength(8).IsFixedLength()
            .IsRequired();
        modelBuilder.Entity<Student>()
            .Property(s => s.UserId)
            .IsRequired();
        modelBuilder.Entity<Tutor>()
            .Property(s => s.UserId)
            .IsRequired();

        modelBuilder.Entity<Thesis>()
            .Property(t => t.Title)
            .HasMaxLength(500).IsFixedLength()
            .IsRequired();
        modelBuilder.Entity<Thesis>()
            .Property(t => t.StartDate);

        modelBuilder.Entity<ThesisState>()
            .Property(t => t.MeetingDate)
            .IsRequired();
    }

}