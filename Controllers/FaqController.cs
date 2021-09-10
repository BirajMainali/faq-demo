using System;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using FAQ.Dto;
using FAQ.Infrastructure.Helper.Interface;
using FAQ.Infrastructure.Provider.Interface;
using FAQ.Repository.Interface;
using FAQ.Services.Interface;
using FAQ.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FAQ.Controllers
{
    public class FaqController : Controller
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IImageHelper _imageHelper;
        private readonly IWebHostEnvironment _env;
        private readonly IUserProvider _userProvider;
        private readonly IFaqService _faqService;
        private readonly INotyfService _notyf;

        public FaqController(IFaqRepository faqRepository,
            IImageHelper imageHelper,
            IWebHostEnvironment env,
            IUserProvider userProvider,
            IFaqService faqService,
            INotyfService notyf
        )
        {
            _faqRepository = faqRepository;
            _imageHelper = imageHelper;
            _env = env;
            _userProvider = userProvider;
            _faqService = faqService;
            _notyf = notyf;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var faqs = await _faqRepository.GetAllAsync();
            return Json(new { faqs });
        }

        [HttpGet]
        [Authorize]
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
                var imagePath = await _imageHelper.UploadImageAndResize(faqViewModel.File, _env.WebRootPath);
                var user = await _userProvider.GetCurrentUser();
                var dto = new FaqDto(user, faqViewModel.Title, faqViewModel.Description, imagePath);
                await _faqService.Create(dto);
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
                var vm = new FaqUpdateViewModel()
                {
                    Title = faq.Title,
                    Description = faq.Description,
                    Image = faq.ImagePath
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
        public async Task<IActionResult> Edit(long id, FaqUpdateViewModel updateViewModel)
        {
            try
            {
                var faq = await _faqRepository.FindOrThrowAsync(id);
                if (!ModelState.IsValid) return RedirectToAction(nameof(Index));
                var user = await _userProvider.GetCurrentUser();
                _imageHelper.Remove(_env.WebRootPath, faq.ImagePath);
                var imagePath = await _imageHelper.UploadImageAndResize(updateViewModel.File, _env.WebRootPath);
                var updateDto = new FaqDto(user, updateViewModel.Title, updateViewModel.Description, imagePath);
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
    }
}