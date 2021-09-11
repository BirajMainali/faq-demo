using FAQ.entities;
using FAQ.Infrastructure;
using FAQ.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Repository
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(DbContext context) : base(context)
        {
        }
    }
}