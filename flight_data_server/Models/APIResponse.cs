using System.Net;

namespace flight_data_server.Models
    {
    public class APIResponse
        {

        public APIResponse()
            {
            ErrorMessage = new List<string>();
            }

        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccess { get; set; }

        public List<String> ErrorMessage { get; set; }

        public object Result { get; set; }
        }
    }
