using ON.Fragments.Content;
using ON.Fragments.Content.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleStats.Service.Data
{
    public interface IStatsContentPublicDataProvider : IGenericRecordDataProvider<StatsContentPublicRecord> { }
    public interface IStatsContentPrivateDataProvider : IGenericRecordDataProvider<StatsContentPrivateRecord> { }
    public interface IStatsUserPublicDataProvider : IGenericRecordDataProvider<StatsUserPublicRecord> { }
    public interface IStatsUserPrivateDataProvider : IGenericRecordDataProvider<StatsUserPrivateRecord> { }

    public interface IGenericRecordDataProvider<T>
    {
        IAsyncEnumerable<T> GetAll();
        Task<T> GetById(Guid recordId);
        Task<bool> Delete(Guid recordId);
        Task<bool> Exists(Guid recordId);
        Task Save(T record);
    }
}
