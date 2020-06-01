using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Application.Common.Exceptions;
using SimpleAgileBoard.Application.Lanes.Services;
using SimpleAgileBoard.Application.Notes.Services;

namespace SimpleAgileBoard.Application.Notes.Commands.MoveNoteToLane
{
    public class MoveNoteToLaneCommandHandler : IRequestHandler<MoveNoteToLaneCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly INoteRepository _noteRepository;
        private readonly ILaneRepository _laneRepository;

        public MoveNoteToLaneCommandHandler(IBoardRepository boardRepository, INoteRepository noteRepository,
            ILaneRepository laneRepository)
        {
            _boardRepository = boardRepository;
            _noteRepository = noteRepository;
            _laneRepository = laneRepository;
        }

        public async Task<BoardViewModel> Handle(MoveNoteToLaneCommand request, CancellationToken cancellationToken)
        {
            var note = await _noteRepository.Get(request.NoteId, cancellationToken);
            if (note == null)
            {
                throw new NotFoundException(nameof(note), request.NoteId);
            }

            var newLane = await _laneRepository.Get(request.NewLaneId, cancellationToken);
            if (newLane == null)
            {
                throw new NotFoundException(nameof(newLane), request.NewLaneId);
            }

            note.LaneId = request.NewLaneId;
            note.SortIndex = newLane.Notes.Count;
            await _noteRepository.SaveChanges(cancellationToken);

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
