using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleAgileBoard.Application.Boards.Queries;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Domain.Entities;
using SimpleAgileBoard.Domain.Extensions;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Notes.Commands.AddNote
{
    public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IApplicationDbContext _applicationDbContext;

        public AddNoteCommandHandler(IBoardRepository boardRepository, IApplicationDbContext applicationDbContext)
        {
            _boardRepository = boardRepository;
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<BoardViewModel> Handle(AddNoteCommand request, CancellationToken cancellationToken)
        {
            var lane = _applicationDbContext.Lanes.FirstOrDefault(x => x.LaneId == request.LaneId);
            var note = new Note
            {
                Title = request.Title,
                Description = request.Description
            };

            lane.AddNote(note);

            _applicationDbContext.Lanes.Update(lane);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var board = _applicationDbContext.Boards
                .Include(x => x.Lanes)
                .ThenInclude(x => x.Notes)
                .FirstOrDefault(x => x.Lanes.Contains(lane))
                .OrderLanesAndNotes();

            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}