using System;

namespace Todo.Models
{
    public class TodoItem : IAuditInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Priority { get; set; }
        public DateTime? ReminderDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public int ListId { get; set; }
        public virtual TodoList List { get; set; }

        public int? ParentId { get; set; }
        public virtual TodoItem Parent { get; set; }
    }
}