using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common.Errors
{
    public enum ErrorType
    {
        BadRequest,
        Validation,
        NotFound,
        Unauthorized,
        Conflict,
        Internal
    }
    public class Error
    {
        public string Message { get; private set; }
        public ErrorType Type { get; private set; }
        public string? Source { get; private set; }

        public Error(string message, ErrorType type, string? source = null)
        {
            Message = message;
            Type = type;
            Source = source;
        }

        public static Error NotFound(string message)
        {
            return new Error(message, ErrorType.NotFound);
        }
        public static Error BadRequest(string message,string? source=null)
        {

            if(source != null)
            {
                return new Error($"{ message} Source is {source }", ErrorType.BadRequest, source);
            }
            return new Error(message, ErrorType.BadRequest);
        }
    }
}
