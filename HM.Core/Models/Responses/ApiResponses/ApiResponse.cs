namespace HM.Core.Models.Responses.ApiResponses;

public class ApiResponse<T>
{
    public ApiResponse()
    {
        Errors = new List<string>();
    }

    public ApiResponseType Type { get; set; }

    public string Message { get; set; }

    public string MoreInfo { get; set; }

    public string ErrorCode { get; set; }

    public T Result { get; set; }

    public List<string> Errors { get; set; }

    public bool HasErrors
    {
        get
        {
            return Errors.Any();
        }
    }
}