using FAQ.entities;
using FAQ.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Repository.Interface
{
    public class FaqTagRepository : BaseRepository<FaqTag>, IFaqTagRepository
    {
        public FaqTagRepository(DbContext context) : base(context)
        {
        }
    }
}