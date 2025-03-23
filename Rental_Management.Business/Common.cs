using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business
{
    public class Common
    {
        enum OperationResult
        {
            Success,
            NotFound,
            HasRelatedRecords,
            ValidationError,
            Unauthorized,
            Forbidden,
            DatabaseError,
            UnknownError
        }
    }
}
