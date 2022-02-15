using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeERP;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace FreeERP.Customers;

public class Customer : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    [NotNull]
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Sort { get; protected set; }
    public virtual Guid? TenantId { get; protected set; }

    private Customer()
    { }
    protected internal Customer(
        Guid id,
        string name,
        string description,
        int sort,
        [CanBeNull] Guid? tenantId = null)
        : base(id)
    {
        SetName(name);
        SetDescription(description);
        SetSort(sort);
        TenantId = tenantId;
    }

    public virtual void SetSort(int sort)
    {
        Sort = sort;
    }

    public virtual void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), CustomerConsts.MaxNameLength);
    }
    public virtual void SetDescription(string description)
    {
        Description = Check.Length(description, nameof(description), CustomerConsts.MaxDescriptionLength);
    }
}
