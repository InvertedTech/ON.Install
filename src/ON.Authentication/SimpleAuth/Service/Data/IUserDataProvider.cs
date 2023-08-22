using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authentication.SimpleAuth.Service.Data
{
    public interface IUserDataProvider
    {
        Task<bool> ChangeEmailIndex(string[] emails, Guid id);
        Task<bool> ChangeLoginIndex(string oldLoginName, string newLoginName, Guid id);
        Task<bool> Create(UserRecord user);
        Task<bool> Delete(Guid userId);
        Task<bool> Exists(Guid userId);
        Task<bool> EmailExists(string email);
        Task<bool> EmailsExist(string[] emails);
        Task<bool> LoginExists(string loginName);
        IAsyncEnumerable<UserRecord> GetAll();
        Guid[] GetAllIds();
        Task<UserRecord> GetById(Guid userId);
        Task<UserRecord> GetByEmail(string email);
        Task<UserRecord> GetByLogin(string loginName);
        Task Save(UserRecord user);
    }
}
