using Ardalis.GuardClauses;
using CrushBadTrait.Core.Interfaces;

namespace CrushBadTrait.Core.Entities;

public class Trait : BaseEntity, IEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double AverageGrade { get; set; } = 0;

    public int DaysOnTrack { get; set; } = 0;
    public List<DayReport>? DayReports { get; init; }

    public Trait() { }
    
    public Trait(Guid userId, string name, string description)
    {
        Guard.Against.Null(name);
        Guard.Against.Null(description);

        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
        Description = description;
    }

    public void UpdateMetrics(int grade)
    {
        UpdateAverageGrade(grade);
        UpdateDaysOnTrack();
    }

    private void UpdateAverageGrade(int grade)
    {
        Guard.Against.Negative(grade);
        
        if (DayReports != null)
        {
            var grades = DayReports.Select(d => d.Grade).ToList();
            grades.Add(grade);
            AverageGrade = grades.Average();
        }
    }

    private void UpdateDaysOnTrack()
    {
        DaysOnTrack++;
    }
}