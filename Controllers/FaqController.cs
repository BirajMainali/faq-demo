using System;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using FAQ.Dto;
using FAQ.Infrastructure.Provider.Interface;
using FAQ.Repository.Interface;
using FAQ.Services.Interface;
using FAQ.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Controllers
{
    public class FaqController : Controller
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IUserProvider _userProvider;
        private readonly IFaqTagService _faqTagService;
        private readonly INotyfService _notyf;
        private readonly ITagRepository _tagRepository;

        public FaqController(IFaqRepository faqRepository,
            IUserProvider userProvider,
            IFaqTagService faqTagService,
            INotyfService notyf,
            ITagRepository tagRepository
        )
        {
            _faqRepository = faqRepository;
            _userProvider = userProvider;
            _faqTagService = faqTagService;
            _notyf = notyf;
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var faqs = await _faqRepository.GetAllAsync();
            return View(faqs);
        }

        [HttpGet]
        public async Task<IActionResult> New()
        {
            var viewModel = new FaqViewModel();
            await LoadTagOptions(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> New(FaqViewModel faqVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await LoadTagOptions(faqVm);
                    return View(faqVm);
                }

                var tags = await _tagRepository.GetQueryable().Where(x => faqVm.TagIds.Contains(x.Id)).ToListAsync();
                var dto = new FaqDto(faqVm.User, faqVm.Question, faqVm.Answer, tags);
                await _faqTagService.Create(dto);
                _notyf.Success("FAQ Created");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _notyf.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(long id)
        {
            try
            {
                var faq = await _faqRepository.FindOrThrowAsync(id);
                var vm = new FaqViewModel()
                {
                    Question = faq.Question,
                    Answer = faq.Answer,
                };
                await LoadTagOptions(vm);
                return View(vm);
            }
            catch (Exception e)
            {
                _notyf.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(long id, FaqViewModel viewModel)
        {
            try
            {
                var faq = await _faqRepository.FindOrThrowAsync(id);
                if (!ModelState.IsValid)
                {
                    await LoadTagOptions(viewModel);
                    return View(viewModel);
                }

                var updateDto = new FaqUpdateDto(viewModel.User, viewModel.Question, viewModel.Answer);
                await _faqTagService.Update(faq, updateDto);
                _notyf.Warning("FAQ Updated");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _notyf.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                var faq = await _faqRepository.FindOrThrowAsync(id);
                await _faqTagService.Remove(faq);
                _notyf.Success("FAQ Removed");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _notyf.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        private async Task LoadTagOptions(FaqViewModel viewModel)
        {
            viewModel.Tags = await _tagRepository.GetAllAsync();
            viewModel.User = await _userProvider.GetCurrentUser();
        }
    }
}