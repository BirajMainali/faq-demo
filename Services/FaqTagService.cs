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
        private readonly IFaqRepository _faqRepository;
        private readonly IFaqTagRepository _faqTagRepository;

        public FaqTagService(IFaqRepository faqRepository, IFaqTagRepository faqTagRepository)
        {
            _faqRepository = faqRepository;
            _faqTagRepository = faqTagRepository;
        }

        public async Task Create(FaqDto dto)
        {
            using var tsc = TransactionScopeHelper.Scope();
            var faq = new Faq(dto.User, dto.Question, dto.Answer);
            foreach (var tag in dto.Tags)
            {
                faq.FaqTags.Add(new FaqTag { Faq = faq, Tag = tag });
            }

            await _faqRepository.CreateAsync(faq);
            await _faqRepository.FlushAsync();
            tsc.Complete();
        }   

        public async Task Update(Faq faq, FaqUpdateDto dto)
        {
            using var tsc = TransactionScopeHelper.Scope();
            faq.Update(dto.User, dto.Question, dto.Answer);
            _faqRepository.Update(faq);
            await _faqRepository.FlushAsync();
            tsc.Complete();
        }

        public async Task Remove(Faq faq)
        {
            using var tsc = TransactionScopeHelper.Scope();
            var tags = await _faqTagRepository.GetAllAsync(x => x.Faq.Id == faq.Id);
            foreach (var tag in tags)
            {
               _faqTagRepository.Remove(tag);
            }
            _faqRepository.Remove(faq);
            await _faqRepository.FlushAsync();
            tsc.Complete();
        }
    }
}