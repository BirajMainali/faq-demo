using System.Threading.Tasks;
using FAQ.Dto;

namespace FAQ.Services.Interface
{
    public interface IFaqTagService
    {
        Task Create(FaqTagDto dto);
    }
}