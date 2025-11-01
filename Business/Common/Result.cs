using Business.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common
{
    public class Result<TValue>
    {
        TValue? _value;
        CommonError? _error;

        public Result(TValue value)
        {
            _value = value;
        }

        public Result(CommonError error)
        {
            _error = error;
        }

        public bool IsSuccess => _value != null;

        public static Result<TValue> Ok(TValue value) => new Result<TValue>(value);
        public static Result<TValue> Fail(CommonError error) => new Result<TValue>(error);
        public TValue Value => _value!;
        public CommonError Error => _error!;
    }
}
