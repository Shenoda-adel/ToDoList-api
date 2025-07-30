namespace ToDoList.Responses
{
    public class ApiResponseMessage
    {
        public string Type { get; set; }
        public string? Field { get; set; }
        public string Text { get; set; }

        public ApiResponseMessage(string type , string field , string text ) 
        {
            Type = type;
            Field = field;
            Text = text;
        }
        public ApiResponseMessage(string type, string text)
        {
            Type = type;
            Field = null;
            Text = text;
        }
    }
}
