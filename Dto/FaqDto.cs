﻿using System.Collections.Generic;
using System.Linq;
using FAQ.entities;

namespace FAQ.Dto
{
    public record FaqDto(User User, string Question, string Answer, List<Tag> Tags);
}