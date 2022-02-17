using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace FreeERP.Products
{
    public class Product : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        [NotNull]
        public virtual Guid CategoryId { get; protected set; }
        [NotNull]
        public virtual string Name { get; protected set; }
        [NotNull]
        public virtual string Code { get; protected set; }
        [CanBeNull]
        public virtual Guid? MediaId { get; protected set; }
        [CanBeNull]
        public virtual string Description { get; protected set; }
        [NotNull]
        public virtual Guid UnitId { get; protected set; }
        [NotNull]
        public List<ProductStock> Stocks { get; protected set; }
        public virtual Guid? TenantId { get; protected set; }

        private Product()
        { }
        protected internal Product(
            Guid id,
            Guid categoryid,
            [NotNull] string name,
            [NotNull] string code,
            [NotNull] Guid unitId,
            [CanBeNull] Guid? mediaId,
            [CanBeNull] string description,
            [CanBeNull] Guid? tenantId = null
        ) : base(id)
        {
            SetCategory(categoryid);
            SetName(name);
            SetCode(code);
            SetMediaId(mediaId);
            SetDescription(description);
            UnitId = unitId;
            Stocks = new List<ProductStock>();
            TenantId = tenantId;
        }


        public virtual void SetCategory(Guid categoryid)
        {
            CategoryId = categoryid;
        }

        public virtual void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), ProductConsts.MaxNameLength);
        }

        public virtual void SetCode(string code)
        {
            Code = Check.NotNullOrWhiteSpace(code, nameof(code), ProductConsts.MaxCodeLength);
        }

        public virtual void SetUnitId(Guid unitId)
        {
            throw new Exception("暂不支持");
        }

        public virtual void SetMediaId(Guid? mediaId)
        {
            MediaId = mediaId;
        }

        public virtual void SetDescription(string description)
        {
            Description = Check.Length(description, nameof(description), ProductConsts.MaxDescriptionLength);
        }

        public virtual void AddStock(Guid stockId, Guid storeId, long num)
        {
            var old = Stocks?.FirstOrDefault(f => f.StoreId == storeId
            );
            if (old != null)
            {
                old.AddStock(num);
                if (old.StockNum == 0)
                    Stocks.Remove(old);
            }
            else
            {
                old = new ProductStock(stockId, storeId, num);
                if (Stocks == null) Stocks = new List<ProductStock>();
                Stocks.Add(old);
            }
            AddLocalEvent(
                new ProductStockChangedEvent
                {
                    ProductId = Id,
                    StoreId = storeId,
                    ChangedNum = num
                }
            );
        }

    }
}