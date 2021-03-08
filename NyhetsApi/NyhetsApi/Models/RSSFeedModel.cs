using System.Collections.Generic;

namespace NyhetsApi.Models
{
    public class RSSFeedModel
    {
        public RSSFeedSourceModel Source { get; set; }
        public IEnumerable<RSSFeedItemModel> Items { get; set; }
    }
}