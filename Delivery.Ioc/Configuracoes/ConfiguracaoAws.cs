using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Delivery.Infrastructure.Options;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentity;

namespace Delivery.Ioc.Configuracoes
{
    internal static class ConfiguracaoAws
    {
        public static IServiceCollection AddAws(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            AWSOptions awsOptions = configuration.GetAWSOptions("AWS");
            string accessKey = configuration.GetSection("AWS:AccessKey").Value;
            string secretKey = configuration.GetSection("AWS:SecretKey").Value;
            string sqsAccessKey = configuration.GetSection("AWS:SqsAccessKey").Value;
            string sqsSecretKey = configuration.GetSection("AWS:SqsSecretKey").Value;
            awsOptions.Credentials = new BasicAWSCredentials(sqsAccessKey, sqsSecretKey);

            services.AddAWSService<IAmazonSQS>(awsOptions);
            services.AddAWSService<IAmazonS3>();

            services.Configure<AwsOptions>(opt =>
            {
                opt.AccessKey = accessKey;
                opt.SecretKey = secretKey;
                opt.Profile = awsOptions.Profile;
                opt.Region = awsOptions.Region.SystemName;
                opt.Bucket = configuration.GetSection("AWS:Bucket").Value;
            });

            var clientS3 = new AmazonS3Client(accessKey, secretKey, RegionEndpoint.SAEast1);
            services.AddSingleton<AmazonS3Client>(x => clientS3);

            var regiao = configuration.GetSection("AWS:Cognito:Autorizacao:Regiao").Value;
            AmazonCognitoIdentityProviderConfig config = new AmazonCognitoIdentityProviderConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(regiao)
            };

            CognitoAWSCredentials credenciais = new CognitoAWSCredentials(configuration.GetSection("AWS:Cognito:Autorizacao:IdentityPoolId").Value, RegionEndpoint.GetBySystemName(regiao));

            var cognitoProvider = new AmazonCognitoIdentityProviderClient(credenciais, config);

            services.AddSingleton<IAmazonCognitoIdentityProvider>(cognitoProvider);

            return services;
        }
    }
}
