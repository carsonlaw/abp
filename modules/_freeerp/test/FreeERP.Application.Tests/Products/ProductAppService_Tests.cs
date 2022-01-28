using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FreeERP.Products;
using Shouldly;
using Volo.Abp.Content;
using Volo.Abp.Domain.Repositories;
using Xunit;
namespace FreeERP.MediaDescriptors
{
    public class ProductAppService_Tests : FreeERPApplicationTestBase
    {
        private Guid mediaId;
        private readonly IProductAppService _productAppService;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductSKURepository _productSkuRepository;
        private readonly IProductUnitRepository _productUnitRepository;

        public ProductAppService_Tests()
        {
            _productAppService = GetRequiredService<IProductAppService>();
            _productRepository = GetRequiredService<IProductRepository>();
            _categoryRepository = GetRequiredService<ICategoryRepository>();
            _productSkuRepository = GetRequiredService<IProductSKURepository>();
            _productUnitRepository = GetRequiredService<IProductUnitRepository>();
        }

        [Fact]
        public async Task Should_Create_Product()
        {
            var category = await _categoryRepository.FirstOrDefaultAsync();
            var unit = await _productUnitRepository.FirstOrDefaultAsync();
            category.ShouldNotBeNull();
            unit.ShouldNotBeNull();

            var productInput = new ProductCreateUpdateDto()
            {
                CategoryId = category.Id,
                UnitId = unit.Id,
                Name = "TestName",
                Code = "TestCode"
            };
            var product = await _productAppService.CreateAsync(productInput);

            product.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Delete_Media()
        {
            await _productAppService.DeleteAsync(mediaId);

            (await _categoryRepository.FindAsync(f => f.Id == mediaId)).ShouldBeNull();
        }
    }
}