using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace EmkiyehSozluk.Infrastructure.Persistence.Context.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<EmkiyehSozlukContext>(conf =>
            {
                var conStr = configuration["EmkiyehSozlukDbConnecitonString"].ToString();
                conf.UseSqlServer(conStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });
            var seedData = new SendDataVirtual();
            seedData.SeedAysnc(configuration).GetAwaiter().GetResult();

            return services;
        }
    }
}
