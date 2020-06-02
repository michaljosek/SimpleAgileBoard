using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Application.Common.Exceptions;
using SimpleAgileBoard.Application.Lanes.Commands.AddLane;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Application.Tests.Lanes.Commands
{
    public class AddLaneCommandHandlerTests
    {
        [Test]
        public void Handle_OnNotExistingBoard_ThrowsNotFoundException()
        {
            var boardRepositoryMock = new Mock<IBoardRepository>();
            boardRepositoryMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Board>(null));

            var sut = new AddLaneCommandHandler(boardRepositoryMock.Object);

            Action act = () => sut.Handle(ExampleQuery, new CancellationToken()).GetAwaiter().GetResult();

            act.Should().ThrowExactly<NotFoundException>();
        }

        [Test]
        public void Handle_OnExistingBoardAndValidData_CallsRepositoryRequiredAmountOfTimes()
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

            var sut = new AddLaneCommandHandler(boardRepositoryMock.Object);

            var result = sut.Handle(ExampleQuery, new CancellationToken()).GetAwaiter().GetResult();

            boardRepositoryMock.Verify(x => x.Update(It.IsAny<Board>(), It.IsAny<CancellationToken>()), Times.Once());
            boardRepositoryMock.Verify(x => x.Get(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
        }

        private static AddLaneCommand ExampleQuery => new AddLaneCommand
        {
            BoardId = 1,
            Name = "Lane"
        };
    }
}
