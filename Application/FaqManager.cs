using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using FAQ.Dto;
using FAQ.entities;
using FAQ.Repository.Interface;
using FAQ.Services.Interface;

namespace FAQ.Application
{
    public class FaqManager : IFAqManager
    {
        private readonly ITagRepository _tagRepository;
        private readonly IFaqService _faqService;
        private readonly IFaqTagService _faqTagService;

        public FaqManager(ITagRepository tagRepository, IFaqService faqService, IFaqTagService faqTagService)
        {
            _tagRepository = tagRepository;
            _faqService = faqService;
            _faqTagService = faqTagService;
        }

        public async Task CreateFaqAndRecordTags(long[] tagIds, FaqDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var faq = await _faqService.Create(dto);
            await RecordTag(tagIds, faq);
            tsc.Complete();
        }

        private async Task RecordTag(IEnumerable<long> tagIds, Faq faq)
        {
            var tags = new List<Tag>();
            foreach (var tagId in tagIds)
            {
                var tag = await _tagRepository.FindOrThrowAsync(tagId);
                tags.Add(tag);
            }

            var faqTagDto = new FaqTagDto()
            {
                Tags = tags,
                Faq = faq
            };
            await _faqTagService.Create(faqTagDto);
        }
    }
}