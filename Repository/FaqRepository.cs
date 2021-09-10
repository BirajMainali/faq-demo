using FAQ.Infrastructure;
using FAQ.Model;
using FAQ.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Repository
{
    public class FaqRepository : BaseRepository<Faq>, IFaqRepository
    {
        public FaqRepository(DbContext context) : base(context)
        {
        }
    }
}