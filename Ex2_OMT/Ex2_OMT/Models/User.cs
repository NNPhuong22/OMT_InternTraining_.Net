using System;
using System.Collections.Generic;

namespace Ex2_OMT.Models
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
            ReplyPosts = new HashSet<ReplyPost>();
            SubReplies = new HashSet<SubReply>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsDisabled { get; set; }
        public int Role { get; set; }

        public virtual Role RoleNavigation { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<ReplyPost> ReplyPosts { get; set; }
        public virtual ICollection<SubReply> SubReplies { get; set; }
    }
}
