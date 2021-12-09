using Microsoft.Extensions.Localization;
using Volo.Match.Localization;
using Volo.Match.Samples;
using Xunit;

namespace Volo.Match.EntityFrameworkCore.Samples
{
    public class SampleRepository_Tests : SampleRepository_Tests<MatchEntityFrameworkCoreTestModule>
    {
        /* Don't write custom repository tests here, instead write to
         * the base class.
         * One exception can be some specific tests related to EF core.
         */
         IStringLocalizer<MatchDBResource> L;
         public SampleRepository_Tests()
         {
             L = GetRequiredService<IStringLocalizer<MatchDBResource>>();
         }

         [Fact]
         public void TestLocalization()
         {
            var s = L["test"];
            Assert.NotNull(s);
         }
    }
}
