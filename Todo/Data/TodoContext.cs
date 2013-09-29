using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Todo.Models;

namespace Todo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        public override int SaveChanges()
        {
            // update created and last modified dates
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity is IAuditInfo && (e.State == EntityState.Added || e.State == EntityState.Modified)))
            {
                var info = entry.Entity as IAuditInfo;
                if (info != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        info.Created = DateTime.Now;
                    }
                    info.LastModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}