using CrushBadTrait.Core.Entities;

namespace UnitTests.Core.Entities;

public class TraitUpdateMetrics
{
    private readonly int _grade = 3;
    private readonly string _name = "Test";
    private readonly string _description = "TestDesc";
    private readonly double _averageGrade = 4.0;
    private readonly int _reportGrade = 4;

    [Fact]
    public void UpdateTraitMetricsSuccess()
    {
        //Arrange
        var trait = new Trait()
        {
            Name = _name,
            Description = _description,
            Id = new Guid(),
            UserId = Guid.Empty,
            DaysOnTrack = 2,
            DayReports = new List<DayReport>()
            {
                new DayReport()
                {
                    Grade = _reportGrade
                },
                new DayReport()
                {
                    Grade = _reportGrade
                }
            }
        };
        
        //Act
        trait.UpdateMetrics(_grade);
        trait.DayReports.Add(new DayReport(){Grade = _grade});
        
        //Assert
        Assert.Equal((double)(_reportGrade + _reportGrade + _grade)/3.0, trait.AverageGrade);
        Assert.Equal(3, trait.DaysOnTrack);
    }
}