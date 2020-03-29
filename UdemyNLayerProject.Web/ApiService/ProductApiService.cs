using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Web.DTOs;

namespace UdemyNLayerProject.Web.ApiService
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;


        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }




        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<ProductDto> categoryDtos;
            var response = await _httpClient.GetAsync("Products");


            if (response.IsSuccessStatusCode)
            {
                categoryDtos = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDtos = null;
            }
            return categoryDtos;


        }




        public async Task<ProductDto> AddAsync(ProductDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Products", stringContent);
            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
                return categoryDto;
            }
            else
            {
                return null;
            }



        }


        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Products/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());

            }
            else
            {
                return null;
            }
        }




        public async Task<bool> Update(ProductDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("Products", stringContent);
            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"Products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;

            }
            else
            {
                return false;
            }
        }



















    }
}
