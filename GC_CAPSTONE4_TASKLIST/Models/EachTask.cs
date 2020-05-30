using System;
using System.Collections.Generic;

namespace GC_CAPSTONE4_TASKLIST.Models
{
    public partial class EachTask
    {
        public EachTask()
        {
            InverseParentTask = new HashSet<EachTask>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Complete { get; set; }
        public bool? Parent { get; set; }
        public int? ParentTaskId { get; set; }
        public string UserId { get; set; }

        public virtual EachTask ParentTask { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<EachTask> InverseParentTask { get; set; }
    }
}
