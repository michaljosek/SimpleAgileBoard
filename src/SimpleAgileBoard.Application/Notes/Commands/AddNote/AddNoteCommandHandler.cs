using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Application.Common.Exceptions;
using SimpleAgileBoard.Application.Lanes.Services;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Application.Notes.Commands.AddNote
{
    public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly ILaneRepository _laneRepository;

        public AddNoteCommandHandler(IBoardRepository boardRepository, ILaneRepository laneRepository)
        {
            _boardRepository = boardRepository;
            _laneRepository = laneRepository;
        }
        
        public async Task<BoardViewModel> Handle(AddNoteCommand request, CancellationToken cancellationToken)
        {
            var lane = await _laneRepository.Get(request.LaneId, cancellationToken);
            if (lane == null)
            {
                throw new NotFoundException(nameof(lane), request.LaneId);
            }
            
            var note = new Note
            {
                Title = request.Title,
                Description = request.Description
            };

            lane.AddNote(note);
            await _laneRepository.Update(lane, cancellationToken);
            var board = await _boardRepository.Get(request.BoardId, cancellationToken);
            if (board == null)
            {
                throw new NotFoundException(nameof(board), request.BoardId);
            }
            
            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}