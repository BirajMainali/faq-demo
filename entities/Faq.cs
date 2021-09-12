using System.Collections.Generic;
using FAQ.Infrastructure;
using FAQ.Infrastructure.Base;
using FAQ.Infrastructure.Base.Interface;
using Microsoft.AspNetCore.Identity;

namespace FAQ.entities
{
    public class Faq : BaseModel, ISoftDelete
    {
        public virtual IdentityUser User { get; protected set; }
        public string Question { get; protected set; }
        public string Answer { get; protected set; }
        public List<FaqTag> FaqTags { get; set; }

        protected Faq()
        {
        }

        public Faq(IdentityUser user, string question, string answer)
            => Copy(user, question, answer);

        public void Update(IdentityUser user, string question, string answer)
            => Copy(user, question, answer);

        private void Copy(IdentityUser user, string question, string answer)
        {
            User = user;
            Question = question;
            Answer = answer;
        }
    }
}