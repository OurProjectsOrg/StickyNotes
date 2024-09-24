using Newtonsoft.Json;
using StickyNotesWebsite.Models;
using System.Text;

namespace StickyNotesWebsite.Services
{
    public static class StickyNotesService
    {
        // GET: Returns all sticky notes in database
        internal static async Task<List<StickyNote>> ReturnAllStickyNote(IConfiguration _config)
        {
            var apiUrl = _config["APIEndpoints:DefaultStickyNoteEndpoint"];
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var mySitckyNoteList = JsonConvert.DeserializeObject<List<StickyNote>>(
                         await response.Content.ReadAsStringAsync());

                    return mySitckyNoteList;
                }
                else
                {
                    return new List<StickyNote>();
                }
            }
        }

        internal static async Task<bool> CreateStickyNote(StickyNote stickyNote, IConfiguration _config)
        {
            var json = JsonConvert.SerializeObject(stickyNote); // or JsonSerializer.Serialize if using System.Text.Json
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
            var apiUrl = _config["APIEndpoints:DefaultStickyNoteEndpoint"];
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





