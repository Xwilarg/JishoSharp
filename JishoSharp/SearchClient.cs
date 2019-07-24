using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace JishoSharp
{
    public static class SearchClient
    {
        /// <summary>
        /// Search for information about a keyword, it can be in kanji, romaji, hiragana or katakana
        /// </summary>
        /// <param name="query">The keyword to search about</param>
        /// <returns>A structure containing information about your query</returns>
        /// <exception cref="HttpRequestException">Error while contacting jisho.org</exception>
        public static async Task<SearchResult.Word[]> SearchWordAsync(string query)
        {
            using (HttpClient hc = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string json = await hc.GetStringAsync("https://jisho.org/api/v1/search/words?keyword=" + Uri.EscapeDataString(query));
                // Make sure that if there is no dbpedia it set it value to null and not to "False"
                json = json.Replace("\"dbpedia\":false", "\"dbpedia\":null");
                // The json have 2 elements, meta and data. We take data and convert it to an array of WordSearchResult
                JObject obj = JObject.Parse(json);
                JToken data = obj.GetValue("data");
                return data.ToObject<SearchResult.Word[]>();
            }
        }
    }
}
