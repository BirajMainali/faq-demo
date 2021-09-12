using System.ComponentModel.DataAnnotations;

namespace FAQ.ViewModel
{
    public class FaqUpdateViewModel
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}