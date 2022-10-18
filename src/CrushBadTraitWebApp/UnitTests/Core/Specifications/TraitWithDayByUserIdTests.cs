using CrushBadTrait.Core.Entities;
using CrushBadTrait.Core.Secifications;

namespace UnitTests.Core.Specifications;

public class TraitWithDayByUserIdTests
{
    private static readonly Guid TestUserId;
    
    private readonly Trait _testTrait1 = new Trait()
    {
        UserId = TestUserId,
        DayReports = new List<DayReport>()
        {
            new DayReport()
            {
                Date = DateTime.Now.AddDays(-1)
            }
        }
    };

    private readonly Trait _testTrait2 = new Trait()
    {
        UserId = TestUserId
    };

    [Fact]
    public void TraitsContainDays()
    {
        var spec = new TraitWithDaysByIdSpecification(TestUserId);

        var result = spec.Evaluate(GetTestTraitCollection()).FirstOrDefault();
        
        Assert.NotNull(result);
        Assert.NotEmpty(result.DayReports);
    }

    private List<Trait> GetTestTraitCollection()
    {
        return new List<Trait>() { _testTrait1, _testTrait2 };
    }
}