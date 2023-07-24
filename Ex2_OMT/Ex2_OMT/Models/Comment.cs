namespace Ex2_OMT.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public int Replier { get; set; }
        public int IsDeleted { get; set; }
        public int? SubCmtOf { get; set; }
        public int? PostId { get; set; }
        public List<Comment> subComments { get; set; }
        public virtual Post Post { get; set; }
        public virtual User ReplierNavigation { get; set; }
    }
}
