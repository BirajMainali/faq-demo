using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using FAQ.Dto;
using FAQ.entities;
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
        private readonly IFaqTagService _faqTagService;
        private readonly ITagRepository _tagRepository;

        public FaqController(IFaqRepository faqRepository,
            IUserProvider userProvider,
            IFaqService faqService,
            INotyfService notyf,
            IFaqTagService faqTagService,
            ITagRepository tagRepository
        )
        {
            _faqRepository = faqRepository;
            _userProvider = userProvider;
            _faqService = faqService;
            _notyf = notyf;
            _faqTagService = faqTagService;
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index() =>
            View(await _faqRepository.GetAllAsync());

        [HttpGet]
        //[Authorize]
        public IActionResult New()
        {
            return View(new FaqViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> New(FaqViewModel faqViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(faqViewModel);
                var user = await _userProvider.GetCurrentUser();
                var dto = new FaqDto(user, faqViewModel.Question, faqViewModel.Answer);
                var faq = await _faqService.Create(dto);
                await RecordTag(faqViewModel.Tags, faq);
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
                if (!ModelState.IsValid) return RedirectToAction(nameof(Index));
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