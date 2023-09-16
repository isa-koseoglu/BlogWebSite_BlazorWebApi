using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return services;
        }
    }
}
