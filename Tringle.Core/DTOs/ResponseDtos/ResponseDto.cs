namespace Tringle.Core.DTOs.ResponseDtos
{
    public abstract class ResponseDto
    {
        public int StatusCode { get; set; }
        public List<string>? Message { get; set; }
    }
}
