using System.Text.Json;

namespace books_list_api.Data.Models
{
    public class ErrorVM
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        public string? Path { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
