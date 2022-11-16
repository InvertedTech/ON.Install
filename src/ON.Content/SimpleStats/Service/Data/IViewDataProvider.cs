using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleStats.Service.Data
{
    public interface IViewDataProvider
    {
        Task LogView(Guid userId, Guid contentId);
    }
}
