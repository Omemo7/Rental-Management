using Business.Application.Abstractions;
using Business.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common
{
    public static class Util
    {
        public static async Task<Result<TReturn, Error>> ResultReturnHandler<TReturn>(
    TReturn result,
    IUnitOfWork _unitOfWork,
    Action? beforSaveOperation = null)
        {
            try
            {
                beforSaveOperation?.Invoke();
                await _unitOfWork.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                return Error.BadRequest("An error occurred: " + ex.InnerException?.Message);
            }
        }

    }
}
