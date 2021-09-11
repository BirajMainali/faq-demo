using FAQ.entities;

namespace FAQ.Dto
{
    public record FaqUpdateDto(User User, string Question, string Answer);
}