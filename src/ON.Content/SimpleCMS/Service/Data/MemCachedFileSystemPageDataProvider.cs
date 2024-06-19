using ON.Fragments.Page;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using System.Linq;

namespace ON.Content.SimpleCMS.Service.Data
{
    public class MemCachedFileSystemPageDataProvider : IPageDataProvider
    {
        private readonly ConcurrentDictionary<Guid, PageRecord> cache = new();
        private readonly FileSystemPageDataProvider dataProvider;

        public MemCachedFileSystemPageDataProvider(FileSystemPageDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            LoadCache().Wait();
        }

        private async Task LoadCache()
        {
            await foreach(var r in dataProvider.GetAll())
            {
                cache.TryAdd(r.Public.PageIDGuid, r);
            }
        }

        public Task<bool> Delete(Guid pageId)
        {
            if (cache.TryRemove(pageId, out var r))
                return dataProvider.Delete(pageId);

            return Task.FromResult(false);
        }

        public Task<bool> Exists(Guid pageId)
        {
            return Task.FromResult(cache.ContainsKey(pageId));
        }

        public IAsyncEnumerable<PageRecord> GetAll()
        {
            return cache.Values.Select(v => v?.Clone()).ToAsyncEnumerable();
        }

        public Task<PageRecord> GetById(Guid pageId)
        {
            if (cache.TryGetValue(pageId, out var record))
                return Task.FromResult(record?.Clone());

            return Task.FromResult((PageRecord)null);
        }

        public Task<PageRecord> GetByURL(string url)
        {
            return Task.FromResult(cache.Values.FirstOrDefault(r => r.Public.Data.URL == url)?.Clone());
        }

        public async Task Save(PageRecord page)
        {
            await dataProvider.Save(page);

            page = await dataProvider.GetById(page.Public.PageIDGuid);

            if (page == null)
                return;

            cache.AddOrUpdate(page.Public.PageIDGuid, page, (k,v) => page);
        }
    }
}
