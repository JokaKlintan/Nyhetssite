using System;

namespace NyhetsApi.Models
{
    public class RSSFeedSourceModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string CopyRight { get; set; }
        public string ManagingEditor { get; set; }
        public string ImageUrl { get; set; }
        public string Language { get; set; }
        public DateTime? LastBuildDate { get; set; }
    }
}