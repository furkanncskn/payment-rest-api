namespace Tringle.Core.DTOs.ResponseDtos
{
    public class ContentResponseDto<T> : ResponseDto
    {
        public T? Data { get; set; }

        public static ContentResponseDto<T> Success(T data)
        {
            return new ContentResponseDto<T> { Data = data };

        }

        public static ContentResponseDto<T> Success(int statusCode, T data)
        {
            return new ContentResponseDto<T> { Data = data, StatusCode = statusCode };
        }
    }
}
