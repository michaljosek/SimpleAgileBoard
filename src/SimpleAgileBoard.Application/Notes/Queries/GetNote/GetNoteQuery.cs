using MediatR;

namespace SimpleAgileBoard.Application.Notes.Queries.GetNote
{
    public class GetNoteQuery : IRequest<NoteViewModel>
    {
        public int NoteId { get; set; }
    }
}