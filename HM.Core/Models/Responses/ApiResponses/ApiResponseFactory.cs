using Microsoft.AspNetCore.Mvc;

namespace HM.Core.Models.Responses.ApiResponses;

public class ApiResponseFactory : IApiResponseFactory
{
    public ApiResponse<object> ErrorResponse(string message)
    {
        var response = new ApiResponse<object>()
        {
            Type = ApiResponseType.Error,
            Errors = new List<string>() { message }
        };
        response.Message = message;
        return response;

    }

    public ApiResponse<object> ModelValidationResponse(SerializableError error)
    {
        var response = new ApiResponse<object>()
        {
            Type = ApiResponseType.Error,
            Errors = new List<string>()
        };

        foreach (var keyValue in error)
        {
            object errorMessages;
            error.TryGetValue(keyValue.Key, out errorMessages);
            response.Errors.AddRange(((string[])errorMessages).Select(x => x.ToString()));
        }

        return response;

    }

    public ApiResponse<object> ErrorResponse(List<string> messages)
    {
        return new ApiResponse<object>()
        {
            Type = ApiResponseType.Error,
            Errors = messages
        };
    }

    public ApiResponse<T> InformationResponse<T>(T result)
    {
        return new ApiResponse<T>()
        {
            Type = ApiResponseType.Information,
            Result = result
        };
    }

    public ApiResponse<T> SuccessResponse<T>(T result)
    {
        return new ApiResponse<T>()
        {
            Type = ApiResponseType.Success,
            Result = result
        };
    }
}