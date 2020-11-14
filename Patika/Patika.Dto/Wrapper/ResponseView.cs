using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Patika.Dto.Wrapper
{
    [Serializable]
    public class ResponseView
    {
        public HttpStatusCode StatusCode { get; set; }

        public bool HasError { get; set; }

        public string Message { get; set; }
    }
}
