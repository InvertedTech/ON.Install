using ON.Fragments.Comment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ON.Content.SimpleComment.Service.Data
{
    public interface ICommentDataProvider
    {
        Task CreateIndexes(CommentRecord record);
        Task<bool> Delete(CommentRecord record);
        Task<bool> Delete(Guid commentId);
        Task DeleteIndexes(CommentRecord record);
        Task<bool> Exists(Guid commentId);
        Task<CommentRecord> Get(Guid commentId);
        IAsyncEnumerable<CommentRecord> GetAll();
        IAsyncEnumerable<CommentRecord> GetByContentId(Guid contentId);
        IAsyncEnumerable<CommentRecord> GetByParentId(Guid parentId);
        Task Insert(CommentRecord record);
        Task Update(CommentRecord record);
    }
}
