using CarPi.Enums.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPi.DTOs.DTO
{
    public class ResponseDTO
    {
        public bool Success { get; set; }

        public ErrorCode? ErrorCode { get; set; }

        public object Data { get; set; }

        public string ErrorMsg
        {
            get
            {
                if (!ErrorCode.HasValue)
                {
                    return null;
                }

                switch (ErrorCode.Value)
                {
                    case CarPi.Enums.Enums.ErrorCode.BadRequest:
                        return "Bad request";
                    case CarPi.Enums.Enums.ErrorCode.NotAuthorized:
                        return "Not authorized";
                    case CarPi.Enums.Enums.ErrorCode.RecordNotFound:
                        return "Record not found";
                    case CarPi.Enums.Enums.ErrorCode.ServerError:
                        return "Server Error";
                    default:
                        return null;
                }
            }
        }

    }
}
