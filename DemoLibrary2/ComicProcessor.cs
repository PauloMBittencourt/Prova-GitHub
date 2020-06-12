using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace DemoLibrary2
{
    public class ComicProcessor
    {
        public int MaxComicNumber { get; set; }

        public async Task<ComicModel> LoadComic(int comicNumber = 0) 
        {
            string url = "";

            if (comicNumber > 0)
            {
                url = $"http://xkcb.com/{ comicNumber }/info.0.json";
            }
            else {
                url = $"http://xkcb.com/info.0.json";
            }
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url)) 
            {

                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();

                    return comic;
                }
                else 
                {
                    throw new Exception(response.ReasonPhrase);
                }
                
            }
        }
    }
}