using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleStats.Service.Data
{
    public interface ILikeDataProvider
    {
        Task Like(Guid userId, Guid contentId);
        Task Unlike(Guid userId, Guid contentId);
    }
}
