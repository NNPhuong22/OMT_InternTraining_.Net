namespace Ex2_OMT.Models
{
    public class ResponseData<T>
    {
        public int? CurrentPage { get; set; }

        public int TotalPage { get; set; }
        public List<T> Data { get; set; }
        public string mess { get; set; }

    }
}