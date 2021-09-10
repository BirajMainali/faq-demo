using System.Threading.Tasks;
using FAQ.Dto;
using FAQ.Infrastructure.Helper;
using FAQ.Model;
using FAQ.Repository.Interface;
using FAQ.Services.Interface;

namespace FAQ.Services
{
    public class FaqService : IFaqService
    {
        private readonly IFaqRepository _faqRepository;

        public FaqService(IFaqRepository faqRepository)
        {
            _faqRepository = faqRepository;
        }

        public async Task Create(FaqDto dto)
        {
            using var tsc = TransactionScopeHelper.Scope();
            var faq = new Faq(dto.User, dto.Title, dto.Description, dto.ImagePath);
            await _faqRepository.CreateAsync(faq);
            await _faqRepository.FlushAsync();
            tsc.Complete();
        }

        public async Task Update(Faq faq, FaqDto dto)
        {
            using var tsc = TransactionScopeHelper.Scope();
            faq.Update(dto.User, dto.Title, dto.Description, dto.ImagePath);
            _faqRepository.Update(faq);
            await _faqRepository.FlushAsync();
            tsc.Complete();
        }

        public async Task Remove(Faq faq)
        {
            using var tsc = TransactionScopeHelper.Scope();
            _faqRepository.Remove(faq);
            await _faqRepository.FlushAsync();
            tsc.Complete();
        }
    }
}