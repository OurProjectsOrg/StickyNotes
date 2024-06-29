using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StickyNotesWebsite.Models;
using System;
using System.Collections;
using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StickyNotesWebsite.Services
{
    public static class StickyNotesService
    {
        // GET: Returns all sticky notes in database
        internal static async Task<List<StickyNote>> ReturnAllStickyNote(IConfiguration _config)
        {
            List<StickyNote> stickyNotesList = new List<StickyNote>();
            var apiUrl = _config["APIEndpoints:DefaultStickyNoteEndpoint"];
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    //var data = await response.Content.ReadAsStringAsync();
                    //var stickyNotes = JsonConvert.DeserializeObject(data);
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
            stickyNote.createdDate = DateTime.Now;
            stickyNote.createdBy = "Guest";
            stickyNote.updated = DateTime.Now;
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





