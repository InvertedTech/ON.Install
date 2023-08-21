using ON.Fragments.Content;
using ON.SimpleWeb.Models.Comment;

namespace ON.SimpleWeb.Models.CMS
{
    public class ViewContentViewModel
    {
        public ContentPublicRecord Record { get; set; }
        public ViewCommentsViewModel Comments { get; set; }
    }
}
