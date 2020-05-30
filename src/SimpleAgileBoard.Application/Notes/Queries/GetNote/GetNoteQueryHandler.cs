using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Notes.Queries.GetNote
{
    public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, NoteViewModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetNoteQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<NoteViewModel> Handle(GetNoteQuery request, CancellationToken cancellationToken)
        {
            var note = _applicationDbContext.Notes.FirstOrDefault(x => x.NoteId == request.NoteId);
            
            return await Task.FromResult(new NoteViewModel
            {
                Note = note
            });
        }
    }
}