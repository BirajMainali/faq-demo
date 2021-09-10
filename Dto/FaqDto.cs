using FAQ.Model;

namespace FAQ.Dto
{
    public record FaqDto(User User, string Title, string Description, string ImagePath);
}