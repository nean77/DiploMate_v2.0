using Microsoft.EntityFrameworkCore;

namespace DiploMate.DAL;

public class DiploMateSeeder
{
    private readonly AppDbContext _ctx;

    public DiploMateSeeder(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public void Seed()
    {
        if (_ctx.Database.CanConnect())
        {
            var pendingMigrations = _ctx.Database.GetPendingMigrations();
            if(pendingMigrations != null && pendingMigrations.Any())
            {
                _ctx.Database.Migrate();
            }

            if (!_ctx.Roles.Any())
            {
                var roles = GetRoles();
                _ctx.Roles.AddRange(roles);
                _ctx.SaveChanges();
            }
        }
    }
    private IEnumerable<Role> GetRoles()
    {
        var roles = new List<Role>()
        {
            new Role()
            {
                Id = 1,
                Name = "Tutor"
            },
            new Role()
            {
                Id = 2,
                Name = "Student"
            },
            new Role()
            {
                Id = 3,
                Name = "Office employee"
            },
            new Role()
            {
                Id = 4,
                Name = "Admin"
            },
        };

        return roles;
    }
    
}