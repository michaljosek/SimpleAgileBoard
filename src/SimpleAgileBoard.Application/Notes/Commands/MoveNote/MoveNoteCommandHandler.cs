using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Application.Lanes.Services;
using SimpleAgileBoard.Domain.Extensions;

namespace SimpleAgileBoard.Application.Notes.Commands.MoveNote
{
    public class MoveNoteCommandHandler : IRequestHandler<MoveNoteCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly ILaneRepository _laneRepository;

        public MoveNoteCommandHandler(IBoardRepository boardRepository, ILaneRepository laneRepository)
        {
            _boardRepository = boardRepository;
            _laneRepository = laneRepository;
        }
        
        public async Task<BoardViewModel> Handle(MoveNoteCommand request, CancellationToken cancellationToken)
        {
            var lane = await _laneRepository.Get(request.LaneId, cancellationToken);
            if (lane == null)
            {
                throw new Exception();
            }
            
            //todo service
            lane.Notes.Move(request.NoteIndex, request.MoveUp);
            await _laneRepository.Update(lane, cancellationToken);
            var board = await _boardRepository.Get(request.BoardId, cancellationToken);

            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}