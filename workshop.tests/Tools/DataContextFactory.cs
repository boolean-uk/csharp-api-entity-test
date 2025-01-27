using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using workshop.wwwapi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace workshop.tests.Tools
{
    public class DataContextFactory
    {
        public static DataContext CreateTestDataContext()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();
            var services = new ServiceCollection();

            // Configure the DbContext for testing
            services.AddDbContext<DataContext>(options =>
            {
                // Use a PostgreSQL database for testing
                var connectionString = configuration.GetConnectionString("DefaultConnectionString");
                options.UseNpgsql(connectionString);

                // Optionally configure warnings for testing
                options.ConfigureWarnings(warnings =>
                    warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            });
            var provider = services.BuildServiceProvider();
            return provider.GetRequiredService<DataContext>();
        }
    }
}
