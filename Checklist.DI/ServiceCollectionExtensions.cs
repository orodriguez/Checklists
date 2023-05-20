using System.Runtime.InteropServices;
using Checklist.Core;
using Checklist.Storage.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Checklist.DI;

public static class ServiceCollectionExtensions
{
    public static void AddApi(this IServiceCollection services)
    {
        services.AddTransient<IApi, Api>();
        services.AddTransient<IChecklistService, ChecklistService>();
        services.AddTransient<IFactory<CreateChecklistRequest, ChecklistEntity>, Factory>();
        services.AddTransient<IRepository<ChecklistEntity>, Repository<ChecklistEntity>>();
        services.AddTransient<IFactory<ChecklistEntity, Core.Checklist>, Factory>();
        services.AddTransient<DbSet<ChecklistEntity>>(provider => provider.GetRequiredService<ChecklistDbContext>().Set<ChecklistEntity>());
        services.AddDbContext<DbContext, ChecklistDbContext>();
        services.AddTransient<DbContextOptions<ChecklistDbContext>>(provider => new DbContextOptionsBuilder<ChecklistDbContext>()
            .UseInMemoryDatabase("UnitTestDatabase")
            .Options);
    }
}