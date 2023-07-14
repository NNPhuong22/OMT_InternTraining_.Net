using System;
using System.Collections.Generic;

namespace OMT_Training_Test.Models
{
    public partial class Tag
    {
        public Tag()
        {
            Tasks = new HashSet<Task>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; }
        public int? OpenNumber { get; set; }
        public int? FinishNumber { get; set; }
        public int? CloseNumber { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
