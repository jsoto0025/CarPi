using CarPooling.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Session
{
    class SessionData : ISessionData
    {
        public UserDTO User { get; set; }
    }
}
