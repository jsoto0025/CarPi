using CarPooling.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Users
{
    public interface IUsersRepository
    {
        UserDTO AreUserAndPasswordValid(string user, string password);
    }
}
