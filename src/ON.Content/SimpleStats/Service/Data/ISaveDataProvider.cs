using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleStats.Service.Data
{
    public interface ISaveDataProvider
    {
        Task Save(Guid userId, Guid contentId);
        Task Unsave(Guid userId, Guid contentId);
    }
}
