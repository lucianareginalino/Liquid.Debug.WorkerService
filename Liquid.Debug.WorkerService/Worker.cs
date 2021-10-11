using Liquid.Debug.Domain.Entities;
using Liquid.Debug.Domain.Handlers;
using Liquid.Messaging;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Liquid.Debug.WorkerService
{
    public class Worker : IWorker<SampleMessage>
    {
        private readonly IMediator _mediator;

        public Worker(IMediator mediator) 
        {
            _mediator = mediator;
        }

        public async Task ProcessMessageAsync(ProcessMessageEventArgs<SampleMessage> args, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CreateCommandRequest(args.Data));
        }

    }
}
