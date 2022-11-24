using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.AliFinds
{
    public class Create
    {
        public class Command : IRequest
        {
            public AliFind AliFind { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
        private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await context.AliFinds.AddAsync(request.AliFind);
                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}