using CarPooling.Configuration.AppConfig;
using CarPooling.DTOs.DTOs;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Users
{
    class UsersRepository : IUsersRepository
    {
        string BaseUrl { get; set; }

        public UsersRepository(IConfiguration configuration)
        {
            BaseUrl = configuration.BaseApiUrl;
        }

        public UserDTO AreUserAndPasswordValid(string user, string password)
        {
            var client = new JsonServiceClient(BaseUrl);

            client.AddHeader("Authorization", "Basic bXlfdXNlcm5hbWU6bXlfcGFzc3dvcmQ=");

            var result = client.Post<UserDTO>("/api/Users/LoginUser",
            new
            {
                Name = user,
                Password = password
            });

            return result;
        }
    }
}
