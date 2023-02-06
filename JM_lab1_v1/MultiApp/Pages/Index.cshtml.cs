using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new System.Net.Http.HttpRequestMessage();
                string url = Environment.GetEnvironmentVariable("WebApiBaseAddress");
                
                request.RequestUri = new Uri(url);
                //request.RequestUri = new Uri("http://service-2:8080/api/Joke");
                //request.RequestUri = new Uri("http://service-api-l1:8080/api/Joke");
                //request.RequestUri = new Uri("http://localhost:53205/api/Joke");

                var response = await client.SendAsync(request);
                var joke = await response.Content.ReadAsStringAsync();

                var details = JObject.Parse(joke);
                ViewData["Joke"] = details["name"] + ";;" + details["text"] + ";;" + details["category"];
            }
        }
    }
}
