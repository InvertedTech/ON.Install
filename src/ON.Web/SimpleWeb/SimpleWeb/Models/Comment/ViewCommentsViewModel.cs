using ON.Fragments.Comment;
using System.Collections.Generic;

namespace ON.SimpleWeb.Models.Comment
{
    public class ViewCommentsViewModel
    {
        public AddCommentViewModel NewComment { get; set; }
        public List<CommentResponseRecord> Records { get; internal set; }
    }
}
