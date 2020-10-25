using System.Collections.Generic;

namespace Calculator.API.ViewModels.Response
{
    public class BaseResponse
    {
        /// <summary>
        /// IsSuccess is set to true if the operation succeeds
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// The status code defines whether an opration succeeded or not. The status code can also be custom
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Errors will contain a list of handled errors including validation errors
        /// </summary>
        public List<string> Errors { get; set; }

        public BaseResponse()
        {
            Errors = new List<string>();
        }

        protected void SetBaseResponseData(bool success, int statusCode, List<string> errors)
        {
            IsSuccess = success;
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}
