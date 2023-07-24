namespace Ex2_OMT.Models
{
    public class ReplyPostDTO
    {
        public int ReplyId { get; set; }
        public string ReplyContent { get; set; }
        public int? PostId { get; set; }
    }
    public class SubReplyDTO
    {
        public int SubId { get; set; }
        public string SubContent { get; set; }
        public int ReplyId { get; set; }
    }
    public class RepplyAddDTO
    {
        public string Content { get; set; }
        public int? ReplyId { get; set; }
        public int? PostId { get; set; }
    }
    public class RepplyEditDTO
    {
        public string Content { get; set; }
        public int? ReplyId { get; set; }
        public int? SubId { get; set; }
        public int? IsDeleted { get; set; }

    }
}
