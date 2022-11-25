namespace HM.Core.Models.Responses.ApiResponses;

public interface IApiResponseFactory
{
    ApiResponse<T> SuccessResponse<T>(T result);
    ApiResponse<object> ErrorResponse(string message);
    ApiResponse<object> ErrorResponse(List<string> messages);

    ApiResponse<T> InformationResponse<T>(T result);
}

