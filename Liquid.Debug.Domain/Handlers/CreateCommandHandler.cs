using Liquid.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Liquid.Debug.Domain.Handlers
{
    public class CreateCommandHandler : IRequestHandler<CreateCommandRequest>
    {
        private readonly ILiquidContext _context;

        public CreateCommandHandler(ILiquidContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCommandRequest request, CancellationToken cancellationToken)
        {
            return new Unit();
        }
    }
}
