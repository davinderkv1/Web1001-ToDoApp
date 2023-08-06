namespace TodoApp.Models
{
    public class TodoItem
    {
        public int ID { get; set; } // Unique identifier for the TodoItem

        public string? Title { get; set; } // The title or name of the TodoItem (nullable string)

        public string? Description { get; set; } // The description or details of the TodoItem (nullable string)

        public bool IsDone { get; set; } // Indicates whether the TodoItem is marked as done (true) or not done (false)
    }
}
