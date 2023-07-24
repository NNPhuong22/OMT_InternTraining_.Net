using System;
using System.Collections.Generic;

namespace Ex2_OMT.Models
{
    public partial class ReplyPost
    {
        public ReplyPost()
        {
            SubReplies = new HashSet<SubReply>();
        }

        public int ReplyId { get; set; }
        public string ReplyContent { get; set; }
        public int Replier { get; set; }
        public int IsDeleted { get; set; }
        public int? PostId { get; set; }

        public virtual Post Post { get; set; }
        public virtual User ReplierNavigation { get; set; }
        public virtual ICollection<SubReply> SubReplies { get; set; }
    }
}
