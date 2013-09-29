using System;
using System.Collections.Generic;

namespace Todo.Models
{
    public class TodoList : IAuditInfo
    {
        public TodoList()
        {
            Items = new List<TodoItem>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<TodoItem> Items { get; set; }
    }
}