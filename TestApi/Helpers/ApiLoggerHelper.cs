using TestApi.Models;

namespace TestApi.Helpers
{
    public static class ApiLoggerHelper
    {
        public static T LogError<T>(ILogger logger, string errorMsg, string scope)
        {
            /*if (typeof(T).IsSubclassOf(typeof(BaseResponse)))
            {
                throw new InvalidOperationException($"{typeof(T).FullName} is not of type BaseReponse");
            }*/

            var response = new BaseResponse
            {
                ErrorMessage =errorMsg,
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            logger.LogError($"Error - {scope}: {response.ErrorMessage}");
            return (T) Convert.ChangeType(response, typeof(T));
        }
    }
}
