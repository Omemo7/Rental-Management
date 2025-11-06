using Business.Application.Abstractions;
using Business.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common
{
    public static class Util
    {
        public static async Task<Result<TReturn, Error>> ResultReturnHandler<TReturn>(
    TReturn result,
    IUnitOfWork? _unitOfWork=null,
    Action? beforSaveOperation = null,
    [CallerMemberName] string methodName = "", // Automatically gets the calling method's name
    [CallerFilePath] string filePath = ""  )   // Automatically gets the full path of the calling file)
        {
            try
            {
                
                beforSaveOperation?.Invoke();
                if(_unitOfWork != null)
                    await _unitOfWork.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                string className = Path.GetFileNameWithoutExtension(filePath);
                string source = $"{className}.{methodName}";
                string errorMessage = "An error occurred: " + (ex.InnerException?.Message ?? ex.Message);
                return Error.BadRequest(errorMessage, source);
            }
        }

    }
}
