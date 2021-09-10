using FAQ.Infrastructure;
using FAQ.Infrastructure.Interface;

namespace FAQ.Model
{
    public class Faq : BaseModel, ISoftDelete
    {
        public virtual User User { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string ImagePath { get; protected set; }

        protected Faq()
        {
        }

        public Faq(User user, string title, string description, string imagePath)
            => Copy(user, title, description, imagePath);

        public void Update(User user, string title, string description, string imagePath)
            => Copy(user, title, description, imagePath);

        private void Copy(User user, string title, string description, string imagePath)
        {
            User = user;
            Title = title;
            Description = description;
            ImagePath = imagePath;
        }
    }
}