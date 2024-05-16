using Microsoft.EntityFrameworkCore;

namespace FileService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<FileDbContext>());
        }
    }

    private static void SeedData(FileDbContext context)
    {
        System.Console.WriteLine("--> Applying migrations...");

        try
        {
            context.Database.Migrate();
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"--> Migration failed {ex.Message}");
        }
    }
    
}