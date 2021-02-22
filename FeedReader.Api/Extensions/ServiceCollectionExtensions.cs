using FeedReader.Core.Config;
using FeedReader.Core.Interfaces;
using FeedReader.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedReader.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNewsFeedDependencies(this IServiceCollection services, string dataLocation, IConfiguration configuration)
        {
            services.Configure<FeedConfig>(configuration);

            //dataservice dependency registration
            services.AddSingleton<IDataService>(new JsonDataService(dataLocation));

            //NewsFeed dependency registration
            services.AddSingleton<NewsFeedService>();
            return services;
        }
    }
}
