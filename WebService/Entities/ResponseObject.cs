using System.Net;
using System.Runtime.Serialization;

namespace WebService.Entities
{
    public class ResponseObject
    {
        public ResponseObject(HttpStatusCode statusCode, string message, string data) 
        { 
            this.StatusCode = statusCode;
            this.Message = message;
            this.Data = data;
        }

        [DataMember(Name = "statusCode")]
        public HttpStatusCode StatusCode { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "exceptionMessage")]
        public object ExceptionMessage { get; set; }

        [DataMember(Name = "data")]
        public object Data { get; set; }
    }
}
