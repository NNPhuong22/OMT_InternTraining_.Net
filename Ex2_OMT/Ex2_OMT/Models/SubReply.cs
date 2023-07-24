using System;
using System.Collections.Generic;

namespace Ex2_OMT.Models
{
    public partial class SubReply
    {
        public int SubId { get; set; }
        public string SubContent { get; set; }
        public int ReplyId { get; set; }
        public int IsDeleted { get; set; }
        public int? Replier { get; set; }

        public virtual User ReplierNavigation { get; set; }
        public virtual ReplyPost Reply { get; set; }
    }
}
