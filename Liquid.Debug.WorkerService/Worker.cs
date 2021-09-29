using Liquid.Debug.Domain.Entities;
using Liquid.Debug.Domain.Handlers;
using Liquid.Messaging;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Liquid.Debug.WorkerService
{
    public class Worker : ConsumerBase<SampleMessage>
    {
        private readonly IMediator _mediator;

        public Worker(IServiceProvider serviceProvider, IMediator mediator) : base(serviceProvider)
        {
            _mediator = mediator;
        }


        public override async Task ProcessMessageAsync(ProcessMessageEventArgs<SampleMessage> args, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CreateCommandRequest(args.Data));
        }

    }
}
