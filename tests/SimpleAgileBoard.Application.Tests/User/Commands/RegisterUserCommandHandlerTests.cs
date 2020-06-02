using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SimpleAgileBoard.Application.User.Commands.RegisterUser;
using SimpleAgileBoard.Application.User.Services;

namespace SimpleAgileBoard.Application.Tests.User.Commands
{
    public class RegisterUserCommandHandlerTests
    {
        [Test]
        public void Handle_OnValidData_ReturnsProperMessage()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock
                .Setup(x => x.RegisterAsync(It.IsAny<RegisterUserCommand>()))
                .Returns(Task.FromResult("some text"));

            var sut = new RegisterUserCommandHandler(userServiceMock.Object);

            var registerCommand = new RegisterUserCommand
            {
                Email = "test@test.pl",
                Password = "test"
            };

            var result = sut.Handle(registerCommand, new CancellationToken());

            result.Should().NotBeNull();
            result.Result.Message.Should().NotBeNull();
            result.Result.Message.Should().Be("some text");
        }
    }
}
