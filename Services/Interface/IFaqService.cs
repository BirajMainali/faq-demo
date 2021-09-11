using System.Threading.Tasks;
using FAQ.Dto;
using FAQ.entities;

namespace FAQ.Services.Interface
{
    public interface IFaqService
    {
        Task<Faq> Create(FaqDto dto);
        Task Update(Faq faq, FaqDto dto);
        Task Remove(Faq faq);
    }
}