﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Common.Exceptions;
using SimpleAgileBoard.Application.Notes.Services;

namespace SimpleAgileBoard.Application.Notes.Queries.GetNote
{
    public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, NoteViewModel>
    {
        private readonly INoteRepository _noteRepository;

        public GetNoteQueryHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        
        public async Task<NoteViewModel> Handle(GetNoteQuery request, CancellationToken cancellationToken)
        {
            var note = await _noteRepository.Get(request.NoteId, cancellationToken);
            if (note == null)
            {
                throw new NotFoundException(nameof(note), request.NoteId);
            }
            
            return new NoteViewModel
            {
                Note = note
            };
        }
    }
}