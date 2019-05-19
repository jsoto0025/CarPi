using CarPooling.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Session
{
    public interface ISessionData
    {
        UserDTO User { get; set; }
    }
}
