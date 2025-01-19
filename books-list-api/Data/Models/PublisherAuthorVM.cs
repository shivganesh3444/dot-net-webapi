namespace books_list_api.Data.Models
{
    public class PublisherAuthorVM
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }

        public List<IEnumerable<string>> Authors { get; set; }
    }
}
