using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.AliFinds
{
    public class Details
    {
        public class Query : IRequest<AliFind> 
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, AliFind>
        {
            private DataContext context;

            public Handler(DataContext context) => this.context = context;

            public async Task<AliFind> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.AliFinds.FindAsync(request.Id);
            }
        }
    }
}