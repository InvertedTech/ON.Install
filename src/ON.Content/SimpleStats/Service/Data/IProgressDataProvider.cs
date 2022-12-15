using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleStats.Service.Data
{
    public interface IProgressDataProvider
    {
        Task LogProgress(Guid userId, Guid contentId, float progress);
    }
}
