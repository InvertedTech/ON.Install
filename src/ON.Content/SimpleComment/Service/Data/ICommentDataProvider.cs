using ON.Fragments.Comment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ON.Content.SimpleComment.Service.Data
{
    public interface ICommentDataProvider
    {
        IAsyncEnumerable<CommentRecord> GetAll();
        IAsyncEnumerable<CommentRecord> GetByContentId(Guid contentId);
        Task<CommentRecord> Get(Guid contentId, Guid commentId);
        Task<bool> Delete(Guid contentId, Guid commentId);
        Task<bool> Exists(Guid contentId, Guid commentId);
        Task Save(CommentRecord content);
    }
}
