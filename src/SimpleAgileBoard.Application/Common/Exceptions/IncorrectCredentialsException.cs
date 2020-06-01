using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAgileBoard.Application.Common.Exceptions
{
    public class IncorrectCredentialsException : Exception
    {
        public IncorrectCredentialsException(string email)
            : base($"Incorrect Credentials for user {email}.")
        {
        }
    }
}
