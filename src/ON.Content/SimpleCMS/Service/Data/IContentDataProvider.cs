using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleCMS.Service.Data
{
    public interface IContentDataProvider
    {
        Task<IEnumerable<ContentRecord>> GetAll();
        Task<ContentRecord> GetById(Guid contentId);
        Task Save(ContentRecord content);
    }
}
