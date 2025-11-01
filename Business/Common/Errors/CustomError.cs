using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common.Errors
{
    public class CustomError: CommonError
    {
        public CustomError(string message) : base(message)
        {
        }
    }
}
