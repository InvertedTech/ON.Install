using NodeF.Fragments.Authentcation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Service.Data
{
    public interface IUserDataProvider
    {
        Task<bool> Create(UserRecord user);
        Task<bool> Exists(Guid userId);
        Task<bool> Exists(string loginName);
        Task<UserRecord> GetById(Guid userId);
        Task<UserRecord> GetByLogin(string loginName);
        Task Save(UserRecord user);
    }
}
