using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace FreeERP.Products
{
    public class ProductUnit : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int RatioCount { get; protected set; }
        public ProductUnit? SmallerUnit { get; protected set; }
        public Collection<ProductUnit> BiggerUnits { get; protected set; }


        private ProductUnit()
        { }
        protected internal ProductUnit(
            Guid id,
            string name,
            string description,
            int ratioCount,
            Collection<ProductUnit> biggerUnits = null)
            : base(id)
        {
            SetName(name);
            SetDescription(description);
            SetRatioCount(ratioCount);
            BiggerUnits = biggerUnits ?? new Collection<ProductUnit>();
        }
        public virtual void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), ProductUnitConsts.MaxNameLength);
        }
        public virtual void SetDescription(string description)
        {
            Description = Check.Length(description, nameof(description), ProductConsts.MaxDescriptionLength);
        }
        public virtual void SetRatioCount(int count)
        {
            if (count <= 0)
                throw new BusinessException(FreeERPDomainErrorCodes.ProductUnit.RatioCoutLeZero);
            RatioCount = count;
        }


    }
}