using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Web.ApiService;
using UdemyNLayerProject.Web.DTOs;

namespace UdemyNLayerProject.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ProductApiService _productApiService;


        public ProductController(IMapper mapper, ProductApiService productApiService)
        {
            _mapper = mapper;
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {


            var Product = await _productApiService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<ProductDto>>(Product));

         
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto categoryDto)
        {
            await _productApiService.AddAsync(categoryDto);

            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Update(int id)
        {
            var category = await _productApiService.GetByIdAsync(id);

            return View(_mapper.Map<ProductDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto categoryDto)
        {
            await _productApiService.Update(categoryDto);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _productApiService.Remove(id);

            return RedirectToAction("Index");
        }










    }
}