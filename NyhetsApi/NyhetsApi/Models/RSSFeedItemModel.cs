using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyhetsApi.Models
{
    public class RSSFeedItemModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Guid { get; set; }
        public DateTime? PubDate { get; set; }
        public string CopyRight { get; set; }
        public string ManagingEditor { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}