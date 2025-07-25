
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NaturalFeelGood.Domain.Interfaces;
using NaturalFeelGood.Infrastructure.Repositories;

namespace NaturalFeelGood.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IAmazonDynamoDB>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var accessKey = configuration["DynamoDbSettings:AccessKey"];
                var secretKey = configuration["DynamoDbSettings:SecretKey"];
                var serviceUrl = configuration["DynamoDbSettings:ServiceURL"];
                var region = configuration["DynamoDbSettings:Region"] ?? "us-east-1";

                var clientConfig = new AmazonDynamoDBConfig
                {
                    ServiceURL = serviceUrl,
                    RegionEndpoint = RegionEndpoint.GetBySystemName(region)
                };

                return new AmazonDynamoDBClient(accessKey, secretKey, clientConfig);
            });

            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
            services.AddScoped<IElementTypeRepository, ElementTypeRepository>();

            return services;
        }
    }
}
