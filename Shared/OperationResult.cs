using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class OperationResult<T> where T : class
    {
        public OperationResultStatus Status { get; set; }
        public T Entity { get; set; }=null!;

    }
}
