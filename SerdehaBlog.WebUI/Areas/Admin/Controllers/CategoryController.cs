﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.CategoryDto;
using System.Text.Json.Serialization;
using System.Text.Json;
using SerdehaBlog.Business.Validations;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public CategoryController(ICategoryService categoryService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Route("/Admin/Kategoriler/")]
        [Route("/Admin/Category/Index/")]
        [Route("/Admin/Category/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Admin/Kategori/Ekle/")]
        [Route("/Admin/Category/Add/")]
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [Route("/Admin/Kategori/Ekle/")]
        [Route("/Admin/Category/Add/")]
        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryDto addCategoryDto)
        {
            Category category = _mapper.Map<Category>(addCategoryDto);
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = await validator.ValidateAsync(category);
            if (result.IsValid)
            {
                await _categoryService.AddAsync(category);
                TempData["IsSuccess"] = $"{category.Name} Başarıyla Eklendi.";
                return Redirect("/Admin/Kategoriler/");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.ErrorMessage);
            }

            return View(addCategoryDto);
        }

        [Route("/Admin/Kategori/Guncelle/{kategoriId?}")]
        [Route("/Admin/Category/Update/{kategoriId?}")]
        [HttpGet]
        public async Task<IActionResult> Update(int categoryId)
        {
            UpdateCategoryDto updateCategoryDto = _mapper.Map<UpdateCategoryDto>(await _categoryService.GetByIdAsync(categoryId));
            return updateCategoryDto != null ? View(updateCategoryDto) : NotFound(404);
        }

        [Route("/Admin/Kategori/Guncelle/")]
        [Route("/Admin/Category/Update/")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            Category category = _mapper.Map<Category>(updateCategoryDto);
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = await validator.ValidateAsync(category);
            if (result.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                category.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                category.ModifiedDate = DateTime.Now;
                await _categoryService.UpdateAsync(category);
                TempData["IsSuccess"] = $"{category.Name} başarıyla güncellendi.";
                return Redirect("/Admin/Kategoriler/");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.ErrorMessage);
            }
            return View(category);
        }

        public async Task<JsonResult> Delete(int categoryId)
        {
            var category = await _categoryService.GetByIdAsync(categoryId);
            if (category != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                await _categoryService.DeleteAsync(category, DateTime.Now, string.Concat(user!.FirstName, " ", user.LastName));
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = category }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        public async Task<JsonResult> GetAllCategories()
        {
            var categories = _mapper.Map<List<ListCategoryDto>>(await _categoryService.GetAllWithFilterAsync(x => !x.IsDeleted, x => x.Articles!));

            if (categories.Any())
            {
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = categories }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }
    }
}
