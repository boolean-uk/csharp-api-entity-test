
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using workshop.wwwapi;

namespace workshop.tests;

public class TestWebApplication : WebApplicationFactory<IApiMarker>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddDbContext<DbContext>(dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
                dbContextOptionsBuilder.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            }, ServiceLifetime.Singleton);
        });

        base.ConfigureWebHost(builder);
    }
}