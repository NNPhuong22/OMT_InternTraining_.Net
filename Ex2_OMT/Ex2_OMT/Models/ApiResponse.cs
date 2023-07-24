namespace Ex2_OMT.Models
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }

        public T? Data { get; set; }

        public List<string> Message { get; set; } = new List<string>();
    }
}
