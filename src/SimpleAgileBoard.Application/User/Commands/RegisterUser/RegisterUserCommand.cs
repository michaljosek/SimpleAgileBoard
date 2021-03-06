﻿using MediatR;

namespace SimpleAgileBoard.Application.User.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisterViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}