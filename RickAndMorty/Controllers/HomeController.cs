using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PagedList;
using RickAndMorty.Models;

namespace RickAndMorty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Episodes()
        {
            List<R1> episodes = await GetAllEpisodesFromAPI();

            return View("Episodes", episodes);
        }

        private async Task<List<R1>> GetAllEpisodesFromAPI()
        {
            List<R1> episodes = new List<R1>();

            using (HttpClient client = new HttpClient())
            {
                string url = "https://rickandmortyapi.com/api/episode";
                string nextPageUrl = url;

                while (!string.IsNullOrEmpty(nextPageUrl))
                {
                    HttpResponseMessage response = await client.GetAsync(nextPageUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Episode episodeResponse = JsonConvert.DeserializeObject<Episode>(jsonResponse);

                        if (episodeResponse.results != null)
                        {
                            episodes.AddRange(episodeResponse.results);
                        }

                        if (!string.IsNullOrEmpty(episodeResponse.info?.next))
                        {
                            nextPageUrl = episodeResponse.info.next;
                        }
                        else
                        {
                            nextPageUrl = null;
                        }
                    }
                    else
                    {
                        // API isteği başarısız oldu
                        // Hata işleme kodlarını burada gerçekleştirin
                        break;
                    }
                }
            }

            return episodes;
        }

        public async Task<IActionResult> Characters()
        {
            List<R2> characters = await GetAllCharactersFromAPI();

            return View("Characters", characters);
        }

        private async Task<List<R2>> GetAllCharactersFromAPI()
        {
            List<R2> characters = new List<R2>();

            using (HttpClient client = new HttpClient())
            {
                string url = "https://rickandmortyapi.com/api/character";
                string nextPageUrl = url;

                while (!string.IsNullOrEmpty(nextPageUrl))
                {
                    HttpResponseMessage response = await client.GetAsync(nextPageUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Character characterResponse = JsonConvert.DeserializeObject<Character>(jsonResponse);

                        if (characterResponse.results != null)
                        {
                            characters.AddRange(characterResponse.results);
                        }

                        if (!string.IsNullOrEmpty(characterResponse.info?.next))
                        {
                            nextPageUrl = characterResponse.info.next;
                        }
                        else
                        {
                            nextPageUrl = null;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return characters;
        }

        public async Task<IActionResult> Locations()
        {
            List<R3> locations = await GetAllLocationsFromAPI();

            return View("Locations", locations);
        }

        private async Task<List<R3>> GetAllLocationsFromAPI()
        {
            List<R3> locations = new List<R3>();

            using (HttpClient client = new HttpClient())
            {
                string url = "https://rickandmortyapi.com/api/location";
                string nextPageUrl = url;

                while (!string.IsNullOrEmpty(nextPageUrl))
                {
                    HttpResponseMessage response = await client.GetAsync(nextPageUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Location locationResponse = JsonConvert.DeserializeObject<Location>(jsonResponse);

                        if (locationResponse.results != null)
                        {
                            locations.AddRange(locationResponse.results);
                        }

                        if (!string.IsNullOrEmpty(locationResponse.info?.next))
                        {
                            nextPageUrl = locationResponse.info.next;
                        }
                        else
                        {
                            nextPageUrl = null;
                        }
                    }
                    else
                    {
                        // API isteği başarısız oldu
                        // Hata işleme kodlarını burada gerçekleştirin
                        break;
                    }
                }
            }

            return locations;
        }
    }
}
