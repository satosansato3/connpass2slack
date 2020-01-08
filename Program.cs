using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Connpass
    {
        public int results_start { get; set; }
        public int results_returned { get; set; }
        public int results_available { get; set; }
        public List<Event> events { get; set; }
    }

    public class Event
    {
        public class Series
        {
            public int id { get; set; }
            public string title { get; set; }
            public string url { get; set; }
        }
        public int event_id { get; set; }
        public string title { get; set; }
        public string @catch { get; set; }
        public string description { get; set; }
        public string event_url { get; set; }
        public DateTime started_at { get; set; }
        public DateTime ended_at { get; set; }
        public int limit { get; set; }
        public string hash_tag { get; set; }
        public string event_type { get; set; }
        public int accepted { get; set; }
        public int waiting { get; set; }
        public DateTime updated_at { get; set; }
        public int owner_id { get; set; }
        public string owner_nickname { get; set; }
        public string owner_display_name { get; set; }
        public string place { get; set; }
        public string address { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public Series series { get; set; }

    }
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "foo=bar");
                var result = await client.GetAsync("https://connpass.com/api/v1/event/?keyword=azure");
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var jsonDes = JsonConvert.DeserializeObject<Connpass>(await result.Content.ReadAsStringAsync(), settings);
                Console.WriteLine(jsonDes.results_start);
            }
        }
    }
}
