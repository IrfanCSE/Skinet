using System;

namespace API.Errors {
    public class ApiResponse {
        public ApiResponse (int statusCode, string message=null) {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefultErrorMessage(statusCode);
        }

        private string GetDefultErrorMessage(int statusCode)
        {
            return statusCode switch{
                400 => "A Bad Request, You Have Made",
                401 => "Authorized, You are not",
                404 => "Request not found",
                500 => "500 Error",
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}