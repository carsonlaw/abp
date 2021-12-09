using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Localization;
using Volo.Match.Domain.LocalizationDB;
using Volo.Match.LocalizationDB;

namespace Volo.Match.EntityFrameworkCore.LocalizationDB
{
    public class DBLocalizationContributor : ILocalizationResourceContributor
    {
        private Dictionary<string, ILocalizationDictionary> _dictionaries;
        ILocalRecordRepository<Guid> _repoLocal;
        private readonly object _syncObj = new object();
        public void Initialize(LocalizationResourceInitializationContext context)
        {
            _repoLocal = context.ServiceProvider.GetRequiredService<ILocalRecordRepository<Guid>>();
        }

        public void Fill(string cultureName, Dictionary<string, LocalizedString> dictionary)
        {
           GetDictionaries().GetOrDefault(cultureName)?.Fill(dictionary);
        }

        public LocalizedString GetOrNull(string cultureName, string name)
        { 
            return GetDictionaries().GetOrDefault(cultureName)?.GetOrNull(name);
        }
        private Dictionary<string, ILocalizationDictionary> GetDictionaries()
        {
            var dictionaries = _dictionaries;
            if (dictionaries != null)
            {
                return dictionaries;
            }
            lock (_syncObj)
            {
                dictionaries = _dictionaries;
                if (dictionaries != null)
                {
                    return dictionaries;
                }
                dictionaries = _dictionaries = CreateDictionaries();
            }
            return dictionaries;
        }
        private Dictionary<string, ILocalizationDictionary> CreateDictionaries()
        {
            var dictionaries = new Dictionary<string, ILocalizationDictionary>();
            
            var culture = _repoLocal.GetQueryableAsync().Result.GroupBy(f=>f.Culture);
            foreach(var c in culture)
            {
                new Dictionary<string, LocalizedString>();
                var list = c.Select(l=>l)
                    .ToDictionary(k=>GetLocalKey(k),v=>new LocalizedString(GetLocalKey(v),v.Value));
                
                dictionaries[c.Key] = new StaticLocalizationDictionary(c.Key,list);
            }
            return dictionaries;
        }

        private string GetLocalKey(LocalizationRecord<Guid> r)
        {
            return $"{r.Column}.{r.RecordId}.{r.Name}";
        }

    }
}