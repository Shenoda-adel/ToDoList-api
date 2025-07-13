namespace Domain
{
    public class TaskFile
    {
        public int Id { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int TaskId { get; set; }
        public ToDoTask Task { get; set; }
    }
}
