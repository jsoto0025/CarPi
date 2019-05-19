using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPi.Enums.Enums
{
    public enum ErrorCode
    {
        BadRequest = 400,
        NotAuthorized = 401,
        RecordNotFound = 404,
        ServerError = 500,
    }
}
