using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common.Errors
{
    public class NotFoundError: CommonError
    {
        public NotFoundError(string message) : base(message)
        {
            
        }
    }
}
