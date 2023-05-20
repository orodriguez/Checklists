using Checklist.Core;
using Microsoft.EntityFrameworkCore;

namespace Checklist.Storage.EF;

public class ChecklistDbContext : DbContext
{
    public DbSet<ChecklistEntity> Checklists { get; set; }
    
    public ChecklistDbContext(DbContextOptions<ChecklistDbContext> options) : base(options)
    {
    }
}