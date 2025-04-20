using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RO.DevTest.Persistence;

public class DefaultContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {

        const string connectionString = "Server=localhost;port=5432;Database=rodevtest;User Id=postgres;Password=27634406gG**;";
        
        var optionsBuilder = new DbContextOptionsBuilder<DefaultContext>();

        optionsBuilder.UseNpgsql(connectionString);
        return new DefaultContext(optionsBuilder.Options);
    }   
}