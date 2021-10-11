using Liquid.Core.Extensions.DependencyInjection;
using Liquid.Core.Implementations;
using Liquid.Core.Interfaces;
using Liquid.Debug.Domain.Entities;
using Liquid.Debug.Domain.Handlers;
using Liquid.Messaging;
using Liquid.Messaging.ServiceBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Liquid.Debug.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //Liquid Core
                    services.AddLiquidConfiguration();
                    services.AddScoped<ILiquidContext, LiquidContext>();

                    //Liquid Domain
                    services.AddAutoMapper(typeof(CreateCommandRequest).Assembly);
                    services.AddMediatR(typeof(CreateCommandRequest).Assembly);

                    //Liquid Messaging
                    services.AddTransient<ILiquidPipeline, LiquidPipeline>();
                    services.AddTransient<IServiceBusFactory, ServiceBusFactory>();

                    services.AddSingleton<ILiquidConsumer<SampleMessage>, ServiceBusConsumer<SampleMessage>>();
                    services.AddScoped<IWorker<SampleMessage>, Worker>();

                    services.AddHostedService<ConsumerBase<SampleMessage>>();
                });
    }
}
