namespace books_list_api.Data.Models
{
    public class PublisherBookVM
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }

        public List<string> Books { get;set; }
    }
}
