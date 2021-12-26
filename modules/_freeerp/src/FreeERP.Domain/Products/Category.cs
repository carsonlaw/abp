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

namespace FreeERP.Products;

public class Category : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    [NotNull]
    public virtual string Name { get; protected set; }
    [NotNull]
    public virtual string Slug { get; protected set; }
    public virtual int Sort { get; protected set; }
    public virtual Guid? Pid { get; protected set; }
    public virtual Guid? TenantId { get; protected set; }

    private Category()
    { }
    protected internal Category(
        Guid id,
        [NotNull] string name,
        [NotNull] string slug,
        [CanBeNull] Guid? pid = null,
        [CanBeNull] Guid? tenantId = null
        ) : base(id)
    {
        SetName(name);
        SetSlug(slug);
        Pid = pid;
        TenantId = tenantId;
    }

    public virtual void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), CategoryConsts.MaxNameLength);
    }

    public virtual void SetSlug(string slug)
    {
        Check.NotNullOrWhiteSpace(slug, nameof(slug), CategoryConsts.MaxSlugLength);
        Slug = SlugNormalizer.Normalize(slug);
    }

    public virtual void SetPid(Guid? pid)
    {
        Pid = pid;
    }
}
