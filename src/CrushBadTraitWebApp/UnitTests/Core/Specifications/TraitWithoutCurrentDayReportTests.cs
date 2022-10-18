using CrushBadTrait.Core.Entities;
using CrushBadTrait.Core.Secifications;

namespace UnitTests.Core.Specifications;

public class TraitWithoutCurrentDayReportTests
{
    private static readonly Guid TestUserId = Guid.NewGuid();
    private static readonly Guid TestTraitId1 = Guid.NewGuid();
    private readonly Guid _testTraitId2 = Guid.NewGuid();
    private static readonly Guid TestTraitId3 = Guid.NewGuid();

    private readonly Trait _testTrait1 = new Trait()
    {
        Id = TestTraitId1,
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
        Id = TestTraitId3,
        UserId = TestUserId
    };

    [Fact]
    private void TraitsMatchesIfNeededDayReportsPresent()
    {
        var spec = new TraitsWithoutCurrentDayReportSpecification(TestUserId);

        var result = spec.Evaluate(GetTestTraitCollection()).FirstOrDefault();

        Assert.NotNull(result);
        Assert.Equal(result.Id, TestTraitId1);
    }

    private List<Trait> GetTestTraitCollection()
    {
        return new List<Trait>()
        {
            _testTrait1,
            _testTrait2,
            new Trait() { Id = TestTraitId3, UserId = TestUserId }
        };
    }
}