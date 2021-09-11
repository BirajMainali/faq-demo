using System.Threading.Tasks;
using FAQ.Dto;
using FAQ.entities;

namespace FAQ.Services.Interface
{
    public interface IFaqTagService
    {
        Task Create(FaqDto dto);
        Task Update(Faq faq, FaqUpdateDto dto);
        Task Remove(Faq faq);
    }
}