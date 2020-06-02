using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using SimpleAgileBoard.Application.Common.Exceptions;
using SimpleAgileBoard.Application.Common.Models;
using SimpleAgileBoard.Application.User.Commands.RegisterUser;
using SimpleAgileBoard.Application.User.Queries.GetToken;
using SimpleAgileBoard.Application.User.Services;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Application.Tests.User.Services
{
    public class UserServiceTests
    {
        [Test]
        public void GetTokenAsync_OnNotFoundUser_ThrowsIncorrectCredentialsException()
        {
            var userManagerWrapperMock = new Mock<IUserManagerWrapper>();
            var jwtTokenMock = new Mock<IOptions<JWT>>();
            userManagerWrapperMock
                .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<ApplicationUser>(null));

            var sut = new UserService(userManagerWrapperMock.Object, jwtTokenMock.Object);

            var getTokenQuery = new GetTokenQuery
            {
                Email = "test@test.pl",
                Password = "test"
            };

            Action act = () => sut.GetTokenAsync(getTokenQuery).GetAwaiter().GetResult();


            act.Should().ThrowExactly<IncorrectCredentialsException>();
        }

        [Test]
        public void GetTokenAsync_OnIncorrectCredentials_ThrowsIncorrectCredentialsException()
        {
            var userManagerWrapperMock = new Mock<IUserManagerWrapper>();
            var jwtTokenMock = new Mock<IOptions<JWT>>();
            userManagerWrapperMock
                .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(Mock.Of<ApplicationUser>()));
            userManagerWrapperMock
                .Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .Returns(Task.FromResult(false));

            var sut = new UserService(userManagerWrapperMock.Object, jwtTokenMock.Object);

            var getTokenQuery = new GetTokenQuery
            {
                Email = "test@test.pl",
                Password = "test"
            };

            Action act = () => sut.GetTokenAsync(getTokenQuery).GetAwaiter().GetResult();


            act.Should().ThrowExactly<IncorrectCredentialsException>();
        }

        [Test]
        public void GetTokenAsync_OnCredentials_ReturnsAuthenticationModel()
        {
            var claims = new List<Claim>()
            {
                new Claim("roles", "test")
            } as IList<Claim>;

            var roles = new List<string>()
            {
                "User"
            } as IList<string>;

            var applicationUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@test.pl",
                UserName = "test@test.pl"
            };

            var jwt = new JWT
            {
                Audience = "test",
                DurationInMinutes = 50,
                Issuer = "test",
                Key = "some_big_key_value_here_secret_123"
            };

            var userManagerWrapperMock = new Mock<IUserManagerWrapper>();
            var jwtTokenMock = new Mock<IOptions<JWT>>();

            jwtTokenMock.Setup(x => x.Value)
                .Returns(jwt);
            userManagerWrapperMock
                .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(applicationUser));
            userManagerWrapperMock
                .Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));
            userManagerWrapperMock
                .Setup(x => x.GetClaimsAsync(It.IsAny<ApplicationUser>()))
                .Returns(Task.FromResult(claims));
            userManagerWrapperMock
                .Setup(x => x.GetRolesAsync(It.IsAny<ApplicationUser>()))
                .Returns(Task.FromResult(roles));

            var sut = new UserService(userManagerWrapperMock.Object, jwtTokenMock.Object);

            var getTokenQuery = new GetTokenQuery
            {
                Email = "test@test.pl",
                Password = "test"
            };

            var result = sut.GetTokenAsync(getTokenQuery).GetAwaiter().GetResult();


            result.Should().NotBeNull();
            result.Email.Should().Be("test@test.pl");
            result.IsAuthenticated.Should().Be(true);
            result.UserName.Should().Be("test@test.pl");
        }
    }
}