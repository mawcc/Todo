using System;

namespace Todo.Models
{
    public interface IAuditInfo
    {
        DateTime Created { get; set; }

        DateTime LastModified { get; set; }
    }
}
