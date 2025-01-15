namespace books_list_api.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Fullname { get; set; }

        //Navigation properties

        public List<Book_Author> Book_Authors { get; set; }
    }
}
