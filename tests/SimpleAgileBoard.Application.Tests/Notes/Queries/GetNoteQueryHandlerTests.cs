using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SimpleAgileBoard.Application.Common.Exceptions;
using SimpleAgileBoard.Application.Notes.Queries.GetNote;
using SimpleAgileBoard.Application.Notes.Services;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Application.Tests.Notes.Queries
{
    public class GetNoteQueryHandlerTests
    {
        [Test]
        public void Handle_OnNotExistingNote_ThrowsNotFoundException()
        {
            var request = new GetNoteQuery
            {
                NoteId = 1
            };

            var noteRepositoryMock = new Mock<INoteRepository>();
            noteRepositoryMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Note>(null));

            var sut = new GetNoteQueryHandler(noteRepositoryMock.Object);

            Action act = () => sut.Handle(request, new CancellationToken()).GetAwaiter().GetResult();

            act.Should().ThrowExactly<NotFoundException>();
        }

        [Test]
        public void Handle_OnExistingNote_ReturnsNoteViewModel()
        {
            var request = new GetNoteQuery
            {
                NoteId = 1
            };
            var note = new Note
            {
                Id = 1,
                Description = "test",
                NoteBoardId = "DSC-11",
                SortIndex = 123,
                Title = "title"
            };

            var noteRepositoryMock = new Mock<INoteRepository>();
            noteRepositoryMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(note));

            var sut = new GetNoteQueryHandler(noteRepositoryMock.Object);

            var result = sut.Handle(request, new CancellationToken()).GetAwaiter().GetResult();

            result.Should().NotBeNull();
            result.Note.Should().NotBeNull();
            result.Note.Id.Should().Be(1);
        }
    }
}
