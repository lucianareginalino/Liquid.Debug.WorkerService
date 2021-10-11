using Liquid.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Liquid.Debug.WorkerService
{
    public class ConsumerBase<TEntity> : BackgroundService
    {
        private ILiquidConsumer<TEntity> _consumer;

        private readonly IServiceProvider _serviceProvider;

        //
        // Summary:
        //     Initialize a new instance of Liquid.Messaging.LiquidConsumerBase`1
        //
        // Parameters:
        //   consumer:
        //     Consumer service with message handler definition for processing messages.
        public ConsumerBase(IServiceProvider serviceProvider, ILiquidConsumer<TEntity> consumer)
        {
            _serviceProvider = serviceProvider;
            _consumer = consumer;
        }

        //
        // Summary:
        //     This method is called when the Microsoft.Extensions.Hosting.IHostedService starts.
        //     Its return a task that represents the lifetime of the long running operation(s)
        //     being performed.
        //
        // Parameters:
        //   stoppingToken:
        //     Triggered when Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)
        //     is called.
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.ProcessMessageAsync += ProcessMessageAsync;
            _consumer.RegisterMessageHandler();

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }

        //
        // Summary:
        //     This method is called when message handler gets a message. The implementation
        //     should return a task that represents the process to be executed by the message
        //     handler.
        //
        // Parameters:
        //   args:
        //
        //   cancellationToken:
        public Task ProcessMessageAsync(ProcessMessageEventArgs<TEntity> args, CancellationToken cancellationToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                var worker = scope.ServiceProvider.GetRequiredService<IWorker<TEntity>>();

               return worker.ProcessMessageAsync(args, cancellationToken);
            }
        }
    }
}
