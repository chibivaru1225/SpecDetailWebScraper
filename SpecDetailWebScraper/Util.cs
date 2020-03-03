using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace SpecDetailWebScraper
{
    public class Util
    {
        public static String search_url = @"https://kakaku.com/search_results/";
        public static String remove_url = @"?lid=pc_ksearch_kakakuitem";
        public static String spec = @"spec";

        public static String NetWorkFolderPath = @"\\zoa.local\zoa\Share\00全社共有\#kakaku_com_pic\";

        /// <summary>
        /// 指定された文字列が URL かどうかを返します
        /// </summary>
        public static bool IsUrl(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(
               input,
               @"^s?https?://[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+$"
            );
        }

        public static String SpecUrl(string url)
        {
            if (IsUrl(url))
            {
                if (url.Contains(Util.spec))
                {
                    return url;
                }
                else if (!url.Contains(Util.spec) && url.EndsWith(@"/"))
                {
                    return url + Util.spec;
                }
                else
                {
                    return url + @"/" + Util.spec;
                }
            }
            else
            {
                return String.Empty;
            }
        }
    }

    public class ResultSpec
    {
        public static String remove2 = @"https://kakaku.com/item/";
        public static String remove3 = @"/spec";

        public static String ImageUrlParts = @"https://kakaku.com/item/{0}/images/";

        public String Title { get; set; }

        public String URL { get; set; }

        public List<Detail> Item { get; set; }

        public List<String> ImageUrls { get; set; }

        public String SearchWord { get; set; }

        public String ItemID
        {
            get
            {
                return this.URL.Replace(remove2, String.Empty).Replace(remove3, String.Empty).Trim();
            }
        }

        public ResultSpec()
        {
            this.Item = new List<Detail>();
            this.ImageUrls = new List<String>();
        }

        public static async Task<ResultSpec> GetTextAsync(string url, string searchword = null)
        {
            var s = new ResultSpec();

            var doc = default(IHtmlDocument);
            using (var client = new HttpClient())
            using (var stream = await client.GetStreamAsync(new Uri(url)))
            {
                // AngleSharp.Parser.Html.HtmlParserオブジェクトにHTMLをパースさせる
                var parser = new HtmlParser();
                doc = parser.ParseDocument(stream);
            }

            // HTMLからtitleタグの値(サイトのタイトルとして表示される部分)を取得する
            var title = doc.QuerySelector(".titie");
            s.Title = doc.Title;
            s.URL = url;
            s.SearchWord = searchword;

            var speclistElement = doc.QuerySelector("[class^=tbl]");

            var specrowlistElement = speclistElement.QuerySelectorAll("tr:not([class^=itemview])");

            foreach (var specrowElement in specrowlistElement)
            {
                var specheaderlistElement = specrowElement.QuerySelectorAll("th");
                var specdetaillistElement = specrowElement.QuerySelectorAll("td");

                foreach (var (specheaderElement, index) in specheaderlistElement.Select((item, index) => (item, index)))
                {
                    if (specheaderElement.TextContent.Trim() != String.Empty)
                    {
                        var detail = new Detail();

                        detail.Key = specheaderElement.TextContent.Trim();
                        detail.Value = specdetaillistElement[index].TextContent.Trim();

                        s.Item.Add(detail);
                    }
                }
            }

            var imagedoc = default(IHtmlDocument);
            using (var client = new HttpClient())
            using (var stream = await client.GetStreamAsync(new Uri(String.Format(ImageUrlParts, s.ItemID))))
            {
                // AngleSharp.Parser.Html.HtmlParserオブジェクトにHTMLをパースさせる
                var parser = new HtmlParser();
                imagedoc = parser.ParseDocument(stream);
            }

            var imageElements = imagedoc.QuerySelectorAll("img");

            foreach (IHtmlImageElement imageElement in imageElements)
            {
                string fullurl = imageElement.Source.Replace("/t/", "/fullscale/");

                if (fullurl.Contains(s.ItemID) && !s.ImageUrls.Contains(fullurl))
                    s.ImageUrls.Add(fullurl);
            }

            var urlword = s.SearchWord ?? s.ItemID;

            DownloadImage.GetImages(Util.NetWorkFolderPath + urlword, s.ImageUrls);

            return s;
        }
    }

    public class Detail
    {
        public String Key { get; set; }

        public String Value { get; set; }
    }

    public class Result
    {
        public ResultTypes Type { get; }

        public String Word { get; set; }

        public DateTime Time { get; set; }

        public int ResultNumber
        {
            get
            {
                switch (this.Type)
                {
                    case ResultTypes.DirectURL:
                        return 1;
                    case ResultTypes.Search:
                        return this.ResultSearch.Specs.Count;
                    default:
                        return 0;
                }
            }
        }

        public ResultSpec ResultSpec { get; }

        public ResultSearch ResultSearch { get; set; }

        public Result(ResultSpec spec)
        {
            ResultSpec = spec;
            Type = ResultTypes.DirectURL;
        }

        public Result(ResultSearch search)
        {
            ResultSearch = search;
            Type = ResultTypes.Search;
        }
    }

    public class ResultSearch
    {
        public List<ResultSpec> Specs { get; set; }

        public ResultSearch()
        {
            Specs = new List<ResultSpec>();
        }
    }

    public class Search
    {
        public List<String> URLs { get; set; }

        public Search()
        {
            URLs = new List<String>();
        }

        public static async Task<Search> GetSearchResult(string modelnumber)
        {
            var s = new Search();
            Encoding enc = Encoding.GetEncoding("shift_jis");
            Console.WriteLine(Util.search_url + HttpUtility.UrlEncode(modelnumber, enc));

            var doc = default(IHtmlDocument);
            using (var client = new HttpClient())
            using (var stream = await client.GetStreamAsync(new Uri(Util.search_url + HttpUtility.UrlEncode(modelnumber, enc))))
            {
                // AngleSharp.Parser.Html.HtmlParserオブジェクトにHTMLをパースさせる
                var parser = new HtmlParser();
                doc = parser.ParseDocument(stream);
            }

            var itemlistElement = doc.QuerySelectorAll(".p-result_item");

            foreach (var itemElement in itemlistElement)
            {
                var urlElement = itemElement.QuerySelectorAll(".p-item_visual").OfType<IHtmlAnchorElement>().FirstOrDefault();

                if (urlElement.Href.Trim() != String.Empty &&
                    urlElement.Href.Contains("redirect") == false &&
                    urlElement.Href.Contains(@"news.kakaku.com") == false)
                    s.URLs.Add(urlElement.Href.Trim().Replace(Util.remove_url, String.Empty));
            }

            return s;
        }
    }

    public class DownloadImage
    {
        public static void GetImages(string folderpath, List<String> imageurls)
        {
            foreach (var imageurl in imageurls)
            {
                if (!imageurl.Contains("fullscale"))
                    continue;

                if (!System.IO.Directory.Exists(folderpath))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(folderpath);
                    }
                    catch
                    {

                    }
                }

                string filename = System.IO.Path.GetFileName(imageurl);

                string filepath = String.Empty;

                if (folderpath.EndsWith(@"\"))
                    filepath = folderpath + filename;
                else
                    filepath = folderpath + @"\" + filename;

                System.Net.WebClient wc = new System.Net.WebClient();

                try
                {
                    wc.DownloadFileAsync(new Uri(imageurl), filepath);
                }
                catch
                {

                }
            }
        }
    }

    public enum ResultTypes
    {
        Search,
        DirectURL,
    }

    public class ResultType
    {
        public static String DispName(ResultTypes type)
        {
            switch (type)
            {
                case ResultTypes.DirectURL:
                    return "URL";
                case ResultTypes.Search:
                    return "検索ワード";
                default:
                    return String.Empty;
            }
        }
    }
}
