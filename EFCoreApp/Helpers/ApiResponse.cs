namespace EFCoreApp.Helpers
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public IEnumerable<T> Data { get; set; }
        public string Message { get; set; }

        public ApiResponse(int status, IEnumerable<T> data, string message)
        {
            Status = status;
            Data = data;
            Message = message;
        }
    }
}
