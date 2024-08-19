namespace NetCoreV2.Areas.Admin.Models
{
    public class BlogModel2
    {
        public int Id { get; set; }
        public string BlogName { get; set; }
        public string BlogDescription { get; set;}
        public string WriterName { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CategoryName { get; set; }
    }
}
