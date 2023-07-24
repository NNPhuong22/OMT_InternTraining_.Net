namespace Ex2_OMT.Models
{
    public partial class CommentPost
    {
        public int CmtId { get; set; }
        public string CmtContent { get; set; }
        public int Replier { get; set; }
        public int IsDeleted { get; set; }
        public int? PostId { get; set; }
        public int? SubCmtOf { get; set; }
        public List<CommentPost> subComments { get; set; }

        public virtual Post Post { get; set; }
        public virtual User ReplierNavigation { get; set; }
    }
}
