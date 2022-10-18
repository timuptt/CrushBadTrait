using CrushBadTrait.Core.Entities;
using CrushBadTrait.Core.Interfaces.Repositories;
using CrushBadTrait.Core.Secifications;
using CrushBadTrait.Core.Services;
using Moq;

namespace UnitTests.Core.Services;

public class DayReportServiceTests
{
    private readonly Mock<IRepository<Trait>> _mockTraitRepository = new();
    private readonly Mock<IRepository<DayReport>> _mockDayReportRepository = new();
    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _traitId = Guid.NewGuid();
    private readonly string _traitName = "Test";

    [Fact]
    public async Task GetTraitIdAndNamesBySpecificationInvokesTraitRepository()
    {
        //Arrange
        var trait = new Trait()
        {
            Id = _traitId,
            UserId = _userId,
            Name = _traitName
        };

        var list = new List<Trait>()
        {
            trait
        };
        _mockTraitRepository.Setup(x =>
                x.ListAsync(It.IsAny<TraitsWithoutCurrentDayReportSpecification>(), default))
            .ReturnsAsync(list);
        var dayReportsService = new DayReportsService(_mockTraitRepository.Object, _mockDayReportRepository.Object);
        
        //Act
        await dayReportsService.GetTraitIdAndNamesToReport(It.IsAny<Guid>());
        
        //Assert
        _mockTraitRepository.Verify(x => 
            x.ListAsync(It.IsAny<TraitsWithoutCurrentDayReportSpecification>(), default),
            Times.Once);
    }
}