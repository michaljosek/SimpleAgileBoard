using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Domain.Extensions;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Notes.Commands.MoveNote
{
    public class MoveNoteCommandHandler : IRequestHandler<MoveNoteCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IApplicationDbContext _applicationDbContext;

        public MoveNoteCommandHandler(IBoardRepository boardRepository, IApplicationDbContext applicationDbContext)
        {
            _boardRepository = boardRepository;
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<BoardViewModel> Handle(MoveNoteCommand request, CancellationToken cancellationToken)
        {
            var lane = _applicationDbContext.Lanes.FirstOrDefault(x => x.LaneId == request.LaneId);

            lane.Notes.Move(request.NoteIndex, request.MoveUp);

            _applicationDbContext.Lanes.Update(lane);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var board = _boardRepository.Get(request.BoardId);

            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}