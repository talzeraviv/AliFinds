using Domain;
using MediatR;
using Persistence;
using AutoMapper;

namespace Application.AliFinds
{
    public class Edit
    {
        public class Command : IRequest
        {
            public AliFind AliFind { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var aliFindToUpdate = await context.AliFinds.FindAsync(request.AliFind.Id); // Get from Db
                
                mapper.Map(request.AliFind, aliFindToUpdate); // Update w/ AutoMapper

                await context.SaveChangesAsync(); // Save Changes to Db

                return Unit.Value;
            }
        }
    }
}