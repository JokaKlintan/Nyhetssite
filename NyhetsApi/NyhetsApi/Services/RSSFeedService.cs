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
        public RSSFeedModel GetRSSFeed(string RSSFEEDUrl)
        {
            RSSFeedModel model = new RSSFeedModel();
            using (WebClient wclient = new WebClient())
            {
                string RSSData = wclient.DownloadString(RSSFEEDUrl);

                XDocument xml = XDocument.Parse(RSSData);

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

                model.Items = (from x in xml.Descendants("item")
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
                                       Category = DecodeUTF8((string)x.Element("category"))
                                   });
            }
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