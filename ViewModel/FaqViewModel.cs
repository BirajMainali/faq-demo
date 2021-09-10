using Microsoft.AspNetCore.Http;

namespace FAQ.ViewModel
{
    public class FaqViewModel
    {
        public IFormFile File { get; set; }
        public string Title { get; set; }
        public string Description { get;set; }
    }
}