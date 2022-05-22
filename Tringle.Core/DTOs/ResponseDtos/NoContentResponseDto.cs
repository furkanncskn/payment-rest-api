namespace Tringle.Core.DTOs.ResponseDtos
{
    public class NoContentResponseDto : ResponseDto
    {
        public static NoContentResponseDto Success(int statusCode)
        {
            return new NoContentResponseDto { StatusCode = statusCode };
        }

        public static NoContentResponseDto Fail(int statusCode, string error)
        {
            return new NoContentResponseDto { StatusCode = statusCode, Message = new List<string> { error } };
        }

        public static NoContentResponseDto Fail(int statusCode, List<string> errors)
        {
            return new NoContentResponseDto { StatusCode = statusCode, Message = errors };
        }
    }
}
