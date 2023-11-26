using AdmBoaFe.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class MeuDbContextFactory : IDesignTimeDbContextFactory<MeuDbContext>
{
    public MeuDbContext CreateDbContext(string[] args)
    {
        var connectionString = "Server=localhost,1433;Initial Catalog=MinhaAppMvcCore;User Id=sa;Password=BirminghamBank!202#;Encrypt=False;TrustServerCertificate=True";

        var optionsBuilder = new DbContextOptionsBuilder<MeuDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new MeuDbContext(optionsBuilder.Options);
    }
}
