namespace books_list_api.Exceptions
{
    public class PublisherNameException : Exception
    {
        public readonly string _publisherName = string.Empty;
        public PublisherNameException()
        {
            
        }
        public PublisherNameException(string message) : base(message)
        {

        }
        public PublisherNameException(string message, Exception ex) : base(message, ex)
        {

        }
        public PublisherNameException(string message, string publisherName) : base(message)
        {
            _publisherName = publisherName;
        }
    }
}
