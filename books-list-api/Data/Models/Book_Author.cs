namespace books_list_api.Data.Models
{
    public class Book_Author
    {
        public int Id { get; set; }

        //Navogation Properties
        public int BookID { get; set; }
        public Book Book { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
