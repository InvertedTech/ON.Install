using System;

namespace ON.Content.SimpleCMS.Web.Models
{
    public class ContentItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
    }
}
