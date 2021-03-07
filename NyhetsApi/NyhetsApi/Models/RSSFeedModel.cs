using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyhetsApi.Models
{
    public class RSSFeedModel
    {
        public RSSFeedSourceModel Source { get; set; }
        public IEnumerable<RSSFeedItemModel> Items { get; set; }
    }
}