using FreeERP.Products;
using FreeERP.Purchase;
using Xunit;

namespace FreeERP.Domain.Tests.Purchase
{
    public class PurchaseOrderTest : FreeERPDomainTestBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductManager _productManager;

        public PurchaseOrderTest()
        {
            _productRepository = GetRequiredService<IProductRepository>();
            _productManager = GetRequiredService<ProductManager>();
        }

        [Fact]
        public void TestName()
        {
            // Given
        
            // When
        
            // Then
        }
    }
}