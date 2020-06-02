using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Application.Common.Exceptions;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Application.Tests.Boards.Queries
{
    public class GetBoardQueryHandlerTests
    {
        [Test]
        public void Handle_OnNotExistingBoard_ThrowsNotFoundException()
        {
            var boardRepositoryMock = new Mock<IBoardRepository>();
            boardRepositoryMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Board>(null));

            var sut = new GetBoardQueryHandler(boardRepositoryMock.Object);

            Action act = () => sut.Handle(ExampleQuery, new CancellationToken()).GetAwaiter().GetResult();

            act.Should().ThrowExactly<NotFoundException>();
        }

        [Test]
        public void Handle_OnExistingBoard_ReturnsBoardViewModel()
        {
            var board = new Board
            {
                Id = 1,
                Name = "Board May 2020",
                NoteCounter = 123,
                NotePrefix = "BM2020"
            };

            var boardRepositoryMock = new Mock<IBoardRepository>();
            boardRepositoryMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(board));

            var sut = new GetBoardQueryHandler(boardRepositoryMock.Object);

            var result = sut.Handle(ExampleQuery, new CancellationToken()).GetAwaiter().GetResult();

            result.Should().NotBeNull();
            result.Board.Should().NotBeNull();
            result.Board.Id.Should().Be(1);
            result.Board.Name.Should().Be("Board May 2020");
        }

        private static GetBoardQuery ExampleQuery => new GetBoardQuery
        {
            BoardId = 1
        };
    }
}
