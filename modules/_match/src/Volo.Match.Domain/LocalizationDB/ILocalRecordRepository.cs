using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Match.LocalizationDB;

namespace Volo.Match.Domain.LocalizationDB
{
    public interface ILocalRecordRepository<T> : IRepository<LocalizationRecord<T>>
    {
         Task<IEnumerable<LocalizationRecord<T>>> GetByRecordIdColum(T recordId);
         Task<bool> Exist(string cultureName,T recordId,string column);
         Task<IEnumerable<LocalizationRecord<T>>> GetByCulture(string cultureName);
    }
}