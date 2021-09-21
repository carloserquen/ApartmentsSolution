using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using Apartments.Data.Repository;
using Apartments.Application.Interfaces;

namespace Apartments.Data
{
    public static class ServiceRegistration
    {
        public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //Add HttpClient Services
            services.AddHttpClient<IApartmentRepository, ApartmentRepository>(c =>
            {
                //c.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", configuration.GetConnectionString("Credential")));
                //c.BaseAddress = new Uri(configuration.GetConnectionString("ExternalAPIUrl"));
                c.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", "YWRtaW46MTIyMDAyMDJjQ0A="));
                c.BaseAddress = new Uri("https://search-apartments-3b6jddrkcvsnteazlvskw56ryq.us-east-2.es.amazonaws.com/properties,mgmt/_search?");
            });
        }
    }
}
