using System;
using System.Collections.Generic;

namespace Ex2_OMT.Models
{
    public partial class Post
    {
        public Post()
        {
            CommentPosts = new HashSet<CommentPost>();
            ReplyPosts = new HashSet<ReplyPost>();
        }

        public int PostId { get; set; }
        public string PostName { get; set; }
        public int Created { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PostContent { get; set; }
        public int IsDeleted { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User CreatedNavigation { get; set; }
        public virtual ICollection<CommentPost> CommentPosts { get; set; }
        public virtual ICollection<ReplyPost> ReplyPosts { get; set; }
    }
}
