using Microsoft.EntityFrameworkCore;


namespace FishPredictor
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FishContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));
        }
    }
}
