using FAQ.entities;
using Microsoft.AspNetCore.Identity;

namespace FAQ.Dto
{
    public record FaqUpdateDto(IdentityUser User, string Question, string Answer);
}