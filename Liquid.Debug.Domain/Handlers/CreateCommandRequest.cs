using Liquid.Debug.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquid.Debug.Domain.Handlers
{
    public class CreateCommandRequest : IRequest
    {
        public SampleMessage Message { get; set; }

        public CreateCommandRequest(SampleMessage message)
        {
            Message = message;
        }
    }
}
