using System;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using FAQ.Application;
using FAQ.Dto;
using FAQ.Infrastructure.Provider.Interface;
using FAQ.Repository.Interface;
using FAQ.Services.Interface;
using FAQ.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FAQ.Controllers
{
    public class FaqController : Controller
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IUserProvider _userProvider;
        private readonly IFaqService _faqService;
        private readonly INotyfService _notyf;
        private readonly ITagRepository _tagRepository;
        private readonly IFAqManager _faqManager;

        public FaqController(IFaqRepository faqRepository,
            IUserProvider userProvider,
            IFaqService faqService,
            INotyfService notyf,
            ITagRepository tagRepository,
            IFAqManager faqManager
        )
        {
            _faqRepository = faqRepository;
            _userProvider = userProvider;
            _faqService = faqService;
            _notyf = notyf;
            _tagRepository = tagRepository;
            _faqManager = faqManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index() =>
            View(await _faqRepository.GetAllAsync());

        [HttpGet]
        public async Task<IActionResult> New()
        {
            var viewModel = new FaqViewModel();
            await LoadTagOptions(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> New(FaqViewModel faqViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await LoadTagOptions(faqViewModel);
                    return View(faqViewModel);
                }

                var user = await _userProvider.GetCurrentUser();
                var dto = new FaqDto(user, faqViewModel.Question, faqViewModel.Answer);
                await _faqManager.CreateFaqAndRecordTags(faqViewModel.TagIds, dto);
                _notyf.Success("Post Created");
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

                var user = await _userProvider.GetCurrentUser();
                var updateDto = new FaqDto(user, viewModel.Question, viewModel.Answer);
                await _faqService.Update(faq, updateDto);
                _notyf.Warning("Post Updated");
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
                await _faqService.Remove(faq);
                _notyf.Success("Post Removed");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _notyf.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        private async Task LoadTagOptions(FaqViewModel viewModel)
            => viewModel.Tags = await _tagRepository.GetAllAsync();
    }
}