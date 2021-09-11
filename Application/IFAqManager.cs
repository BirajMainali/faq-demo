using System.Threading.Tasks;
using FAQ.Dto;
using FAQ.ViewModel;

namespace FAQ.Application
{
    public interface IFAqManager
    {
        Task CreateFaqAndRecordTags(long[] tagIds, FaqDto dto);
    }
}