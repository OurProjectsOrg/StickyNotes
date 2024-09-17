using Newtonsoft.Json;
using StickyNotesWebsite.Models;
using System.Text;

namespace StickyNotesWebsite.Services
{
    public static class CategoryService
    {
        internal static async Task<List<Category>> ReturnAllCategories(IConfiguration _config)
        {
            var apiUrl = _config["APIEndpoints:DefaultCategoryEndpoint"];
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var categoriesList = JsonConvert.DeserializeObject<List<Category>>(
                         await response.Content.ReadAsStringAsync());

                    return categoriesList;
                }
                else
                {
                    return new List<Category>();
                }
            }
        }


        internal static async Task<bool> CreateCategory(Category category, IConfiguration _config)
        {
            category.createdDate = DateTime.Now;
            category.createdBy = "Guest";
            var json = JsonConvert.SerializeObject(category); // or JsonSerializer.Serialize if using System.Text.Json
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
            var apiUrl = _config["APIEndpoints:DefaultCategoryEndpoint"];
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync(apiUrl, stringContent);
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
}
