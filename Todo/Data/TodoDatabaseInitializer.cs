using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Todo.Models;

namespace Todo.Data
{
    public class TodoDatabaseInitializer : DropCreateDatabaseAlways<TodoContext>
    {
        protected override void Seed(TodoContext context)
        {
            var list = new TodoList
            {
                Title = "Einkaufsliste",
                Description = "Beispiel für eine einfache Einkaufsliste"
            };
            context.TodoLists.Add(list);

            var item = new TodoItem
            {
                Title = "Milch"
            };
            list.Items.Add(item);
            item = new TodoItem
            {
                Title = "Butter"
            };
            list.Items.Add(item);
            item = new TodoItem
            {
                Title = "Brot"
            };
            list.Items.Add(item);

            list = new TodoList
            {
                Title = "Website Freigabeliste",
                Description = "Beispiel für eine Website Freigabeliste"
            };
            context.TodoLists.Add(list);
            item = new TodoItem
            {
                Title = "META Tags",
                Description = "Sind alle wichtigen META Tags gesetzt?",
                Priority = 2
            };
            list.Items.Add(item);
            item = new TodoItem
            {
                Title = "Title Tags",
                Description = "Haben alle Seitentitel sinnvolle Werte?",
                Priority = 1
            };
            list.Items.Add(item);
            item = new TodoItem
            {
                Title = "Base URLs",
                Description = "Verwenden alle URLs relative Adressen bzw. falls nicht die richtige Base URL?",
                Priority = 1
            };
            list.Items.Add(item);

            base.Seed(context);
        }
    }
}