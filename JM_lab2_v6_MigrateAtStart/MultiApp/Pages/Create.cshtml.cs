using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;
using MultiApp.Models;
using System.Text.Json;
using System.Security.Policy;
using System;
using System.Text;

namespace MultiApp.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Joke Joke { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //string url = "http://localhost:53205/api/Jokes";                       //for single service
            //request.RequestUri = new Uri("http://l2-service-apipost:8080/api/JokesPost");

            //string url = "http://localhost:48943/api/JokesPost";
            
            string url = Environment.GetEnvironmentVariable("WebApiPostBaseAddress");

            HttpResponseMessage response = null;
            string jsonFormat = JsonSerializer.Serialize(Joke);
            var jsonToSend = new StringContent(jsonFormat, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                response = await client.PostAsync(url, jsonToSend);
            };

            return RedirectToPage("./Index");
        }
    }
}
