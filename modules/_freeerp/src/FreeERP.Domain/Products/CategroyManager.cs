using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;
using Volo.Abp.Domain.Repositories;
namespace FreeERP.Products
{
    public class CategroyManager : DomainService
    {
        protected ICategoryRepository CategroyRepository;

        public CategroyManager(ICategoryRepository repository)
        {
            CategroyRepository = repository;
        }
        public virtual async Task<Category> CreateAsync([NotNull] string name, [NotNull] string slug, [CanBeNull] Guid? pid = null)
        {
            await CheckSlugAsync(slug);
            return new Category(GuidGenerator.Create(), name, slug, pid, CurrentTenant.Id);
        }

        public virtual async Task<Category> UpdateAsync([NotNull] Category cate, [NotNull] string name, [NotNull] string slug, [CanBeNull] Guid? pid = null)
        {
            if (slug != cate.Slug)
            {
                await CheckSlugAsync(slug);
            }
            if (pid != cate.Pid)
            {
                await CheckPidAsync(cate.Id, pid);
            }

            cate.SetName(name);
            cate.SetSlug(slug);
            cate.SetPid(pid);

            return cate;
        }

        protected virtual async Task CheckPidAsync(Guid Id, Guid? Pid)
        {
            var ids = await CategroyRepository.GetAllChildById(Id);
            if (Id == Pid || ids.Contains(Pid.Value))
            {
                throw new CategoryPidReferenceLoopException(Id, Pid);
            }
        }

        protected virtual async Task CheckSlugAsync([NotNull] string slug)
        {
            if (await CategroyRepository.SlugExistsAsync(slug))
            {
                throw new CategorySlugAlreadyExistException(slug);
            }
        }
    }
}