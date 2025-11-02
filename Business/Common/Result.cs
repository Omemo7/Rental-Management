using Business.Common;
using Business.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common
{
    public class Result<TValue,TError> 
       
    {
        TValue? _value;
        TError? _error;

        public Result(TValue value)
        {
            _value = value;
          
        }

        public Result(TError error)
        {
            _error = error;
           
        }

        public bool IsSuccess => _error == null;

        public static implicit operator Result<TValue, TError>(TValue value)
        {
            return new Result<TValue, TError>(value);
        }
        public static implicit operator Result<TValue, TError>(TError error)
        {
            return new Result<TValue, TError>(error);
        }
        public TValue Value => _value!;
        public TError Error => _error!;
    }
}


