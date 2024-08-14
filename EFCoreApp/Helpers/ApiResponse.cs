namespace EFCoreApp.Helpers
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public ApiResponse(int status, T data, string message)
        {
            Status = status;
            Data = data;
            Message = message;
        }
    }
}
