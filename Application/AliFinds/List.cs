using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AliFinds
{
    public class List
    {
        public class Query : IRequest<List<AliFind>>{}

        public class Handler : IRequestHandler<Query, List<AliFind>>
        {
            private readonly DataContext context;
            public Handler(DataContext context) => this.context = context;

            public async Task<List<AliFind>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.AliFinds.ToListAsync();
            }
        }
    }
}