namespace OMT_Training_Test.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }

        public string TaskDescription { get; set; }
        public DateTime FinishDate { get; set; }
        public int? Status { get; set; }
        public int? TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
