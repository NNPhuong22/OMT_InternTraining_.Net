namespace OMT_Training_Test.Models
{
    public class ResponseData<T>
    {
        public int? CurrentPage { get; set; }

        public int TotalPage { get; set; }
        public List<T> Data { get; set; }

    }
}
