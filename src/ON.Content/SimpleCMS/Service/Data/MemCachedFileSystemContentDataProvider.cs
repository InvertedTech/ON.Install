using ON.Fragments.Content;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using System.Linq;

namespace ON.Content.SimpleCMS.Service.Data
{
    public class MemCachedFileSystemContentDataProvider : IContentDataProvider
    {
        private readonly ConcurrentDictionary<Guid, ContentRecord> cache = new();
        private readonly FileSystemContentDataProvider dataProvider;

        public MemCachedFileSystemContentDataProvider(FileSystemContentDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            LoadCache().Wait();
        }

        private async Task LoadCache()
        {
            await foreach(var r in dataProvider.GetAll())
            {
                cache.TryAdd(r.Public.ContentIDGuid, r);
            }
        }

        public Task<bool> Delete(Guid contentId)
        {
            if (cache.TryRemove(contentId, out var r))
                return dataProvider.Delete(contentId);

            return Task.FromResult(false);
        }

        public Task<bool> Exists(Guid contentId)
        {
            return Task.FromResult(cache.ContainsKey(contentId));
        }

        public IAsyncEnumerable<ContentRecord> GetAll()
        {
            return cache.Values.Select(v => v?.Clone()).ToAsyncEnumerable();
        }

        public Task<ContentRecord> GetById(Guid contentId)
        {
            if (cache.TryGetValue(contentId, out var record))
                return Task.FromResult(record?.Clone());

            return Task.FromResult((ContentRecord)null);
        }

        public Task<ContentRecord> GetByURL(string url)
        {
            return Task.FromResult(cache.Values.FirstOrDefault(r => r.Public.Data.URL == url)?.Clone());
        }

        public async Task Save(ContentRecord content)
        {
            await dataProvider.Save(content);

            content = await dataProvider.GetById(content.Public.ContentIDGuid);

            if (content == null)
                return;

            cache.AddOrUpdate(content.Public.ContentIDGuid, content, (k,v) => content);
        }
    }
}
