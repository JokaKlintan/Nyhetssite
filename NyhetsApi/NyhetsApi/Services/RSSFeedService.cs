using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using NyhetsApi.Models;

namespace NyhetsApi.Services
{
    public class RSSFeedService
    {
        public RSSFeedModel GetRSSFeed(string[] RSSFEEDUrlArray, bool includeSource = false)
        {
            RSSFeedModel model = new RSSFeedModel();
            List<RSSFeedItemModel> list = new List<RSSFeedItemModel>();

            using (WebClient wclient = new WebClient())
            {
                foreach(string url in RSSFEEDUrlArray)
                {
                    string RSSData = wclient.DownloadString(url);
                    XDocument xml = XDocument.Parse(RSSData);

                    if (includeSource)
                    {
                        model.Source = (from x in xml.Descendants("channel")
                                        select new RSSFeedSourceModel
                                        {
                                            Title = DecodeUTF8((string)x.Element("title")),
                                            Description = DecodeUTF8((string)x.Element("description")),
                                            Link = (string)x.Element("link"),
                                            CopyRight = DecodeUTF8((string)x.Element("copyright")),
                                            ManagingEditor = DecodeUTF8((string)x.Element("managingEditor")),
                                            Language = DecodeUTF8((string)x.Element("language")),
                                            LastBuildDate = (DateTime?)x.Element("lastBuildDate"),
                                            ImageUrl = (string)x.Element("image") != null ? (string)x.Element("image").Element("url") : null
                                        }).FirstOrDefault();
                    }

                    list = list.Concat(from x in xml.Descendants("item")
                                       select new RSSFeedItemModel
                                       {
                                           Title = DecodeUTF8((string)x.Element("title")),
                                           Link = (string)x.Element("link"),
                                           Description = DecodeUTF8((string)x.Element("description")),
                                           PubDate = (DateTime?)x.Element("pubDate"),
                                           Guid = DecodeUTF8((string)x.Element("guid")),
                                           CopyRight = DecodeUTF8((string)x.Element("copyright")),
                                           ManagingEditor = DecodeUTF8((string)x.Element("managingEditor")),
                                           Author = DecodeUTF8((string)x.Element("author")),
                                           Category = DecodeUTF8((string)x.Element("category")),
                                           Source = url
                                       }).ToList();
                }
            }
            model.Items = list.OrderByDescending(x => x.PubDate);
            return model;
        }

        private string DecodeUTF8(string decoded)
        {
            if (!string.IsNullOrEmpty(decoded))
            {
                byte[] bytes = Encoding.Default.GetBytes(decoded);
                return Encoding.UTF8.GetString(bytes);
            }
            return null;
        }
    }
}