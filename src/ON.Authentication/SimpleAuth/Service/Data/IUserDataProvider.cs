using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authentication.SimpleAuth.Service.Data
{
    public interface IUserDataProvider
    {
        Task<bool> ChangeLogin(string oldLoginName, string newLoginName, Guid id);
        Task<bool> Create(UserRecord user);
        Task<bool> Delete(Guid userId);
        Task<bool> Exists(Guid userId);
        Task<bool> Exists(string loginName);
        IAsyncEnumerable<UserRecord> GetAll();
        Task<UserRecord> GetById(Guid userId);
        Task<UserRecord> GetByLogin(string loginName);
        Task Save(UserRecord user);
        Task ReindexAll();
    }
}
