using System.Threading.Tasks;
using FAQ.Dto;
using FAQ.Model;

namespace FAQ.Services.Interface
{
    public interface IFaqService
    {
        Task Create(FaqDto dto);
        Task Update(Faq faq, FaqDto dto);
        Task Remove(Faq faq);
    }
}