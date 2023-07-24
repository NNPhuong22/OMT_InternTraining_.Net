namespace Ex2_OMT.Models
{
    public class PostAddDTO
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string PostContent { get; set; }
        public int CategoryId { get; set; }
    }
    public class PostEditDTO
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string PostContent { get; set; }
        public int CategoryId { get; set; }
    }
}
