using System.Collections.Generic;
using System.Threading.Tasks;
using FAQ.Dto;
using FAQ.entities;
using FAQ.Infrastructure.Helper;
using FAQ.Repository.Interface;
using FAQ.Services.Interface;

namespace FAQ.Services
{
    public class FaqTagService : IFaqTagService
    {
        private readonly IFaqTagRepository _tagRepository;

        public FaqTagService(IFaqTagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task Create(FaqTagDto dto)
        {
            using var tsc = TransactionScopeHelper.Scope();
            foreach (var tag in dto.Tags)
            {
                var model = new FaqTag()
                {
                    Faq = dto.Faq,
                    Tag = tag
                };
                await _tagRepository.CreateAsync(model);
                await _tagRepository.FlushAsync();
            }

            tsc.Complete();
        }
        
    }
}