namespace books_list_api.Data.Models
{
    public class AuthorWithBookVM
    {
        public string Fullname { get; set; }
        public List<string> Books { get; set; }
    }
}
