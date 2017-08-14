using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpiderAngleSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cnblogs =  Spider();
            Console.Read();
        }


        public async static Task<List<Cnblogs>> Spider()
        {
            using (var client = new HttpClient())
            {
                var url = "https://www.cnblogs.com/";
                var content = await client.GetStringAsync(url);

                HtmlParser parser = new HtmlParser();
                var cnblogs = parser.Parse(content)
                           .QuerySelectorAll(".post_item_body")
                           .Select(g => new Cnblogs
                           {
                               Title = g.QuerySelectorAll(".titlelnk").FirstOrDefault().TextContent,
                               Url = g.QuerySelectorAll(".titlelnk").FirstOrDefault().Attributes.First(t => t.Name == "href").Value,
                               PicUrl =g.QuerySelectorAll(".post_item_summary a img").FirstOrDefault()?.Attributes.First(t => t.Name == "src").Value,
                           }).ToList();

                cnblogs.ForEach(g =>
                {
                    if (!string.IsNullOrEmpty(g.PicUrl))
                    {
                        g.PicUrl = "https:" + g.PicUrl;
                    }
                });

                return cnblogs;
            }
        }


        public class Cnblogs
        {
            public string Title { get; set; }
            public string Url { get; set; }
            public string PicUrl { get; set; }
        }
    }
}