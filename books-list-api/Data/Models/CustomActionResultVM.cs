namespace books_list_api.Data.Models
{
    public class CustomActionResultVM
    {
        public CustomActionResultVM()
        {
            
        }
        public Exception Exception { get; set; }
        public List<Publisher> Publishers { get; set; }
    }
}
