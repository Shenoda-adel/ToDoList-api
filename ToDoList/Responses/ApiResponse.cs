namespace ToDoList.Responses
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public IEnumerable<T>? Data { get; set; }
        public List<ApiResponseMessage> Message { get; set; }

        public ApiResponse(int status , IEnumerable<T> data , List<ApiResponseMessage> message)
        {
            Status = status;
            Data = data;
            Message = message;
        }   
        public ApiResponse(int status, List<ApiResponseMessage> message)
        {
            Status = status;
            Data = null;
            Message = message;
        }   
    }
}
