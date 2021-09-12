using System.Collections.Generic;
using System.Linq;
using FAQ.entities;
using Microsoft.AspNetCore.Identity;

namespace FAQ.Dto
{
    public record FaqDto(IdentityUser User, string Question, string Answer, List<Tag> Tags);
}