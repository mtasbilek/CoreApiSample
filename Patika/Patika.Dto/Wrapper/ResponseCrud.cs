using Patika.Dto.Enums;
using System.Net;

namespace Patika.Dto.Wrapper
{
    public class ResponseCrud<T> where T : class, new()
    {
        public ResponseCrud(HttpStatusCode statusCode, CrudEnum crudJob, bool hasError = false, string errorMessage = null, T t = null)
        {
            Status = statusCode;
            CrudJob = crudJob;
            HasError = hasError;
            ErrorMessage = errorMessage;
            Entity = t;
        }
        public HttpStatusCode Status { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public CrudEnum CrudJob { get; set; }
        public T Entity { get; set; }
    }
}