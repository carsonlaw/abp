using Volo.Abp.Domain.Entities;

namespace Volo.Match.LocalizationDB
{
    public class LocalizationRecord<T> : Entity
    {
        public string Culture {get;set;}
        public T RecordId {get;set;}
        public string Column {get;set;}
        public string Name {get;set;}
        public string Value {get;set;}

        public override object[] GetKeys()
        {
            return new object[]{Culture,RecordId,Column};
        }
    }
}