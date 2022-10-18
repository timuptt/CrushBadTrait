using CrushBadTrait.Core.Entities;
using CrushBadTrait.Core.Interfaces.Repositories;
using CrushBadTrait.Core.Services;
using Moq;

namespace UnitTests.Core.Services;

public class TraitServiceTests
{
    private readonly Guid _traitId = Guid.NewGuid();
    private readonly string _name = "TestName";
    private readonly string _description = "TestDescription";
    private readonly double _averageGrade = 4.0;
    private readonly Guid _userId = Guid.NewGuid();
    private readonly int _daysOnTrack = 2;

    private readonly Mock<IRepository<Trait>> _mockTraitRepo = new();
    
    [Fact]
    public async Task CreateTraitInvokesTraitRepositoryOnce()
    {
        //Arrange
        _mockTraitRepo.Setup(x => 
            x.AddAsync(It.IsAny<Trait>(), default))
            .ReturnsAsync(It.IsAny<Trait>());
        var traitService = new TraitService(_mockTraitRepo.Object);

        //Act
        await traitService.CreateTrait(_userId, _name, _description);
        
        
        //Assert
        _mockTraitRepo.Verify(x => 
            x.AddAsync(It.IsAny<Trait>(), default), Times.Once);
    }

    [Fact]
    public async Task UpdateTraitInvokesTraitRepositoryOnce()
    {
        //Arrange
        _mockTraitRepo.Setup(x =>
            x.GetByIdAsync(It.IsAny<Guid>(), default))
            .ReturnsAsync(It.IsAny<Trait>());
        var traitService = new TraitService(_mockTraitRepo.Object);
        
        //Act
        await traitService.UpdateTrait(It.IsAny<Guid>(), _name, _description);
        
        //Assert
        _mockTraitRepo.Verify(x => 
            x.GetByIdAsync(It.IsAny<Guid>(), default), Times.Once);

    }

    [Fact]
    public async Task DeleteTraitInvokesTraitRepositoryOnce()
    {
        //Arrange
        _mockTraitRepo.Setup(x =>
                x.GetByIdAsync(It.IsAny<Guid>(), default))
            .ReturnsAsync(It.IsAny<Trait>());
        var traitService = new TraitService(_mockTraitRepo.Object);
        
        //Act
        await traitService.DeleteTrait(It.IsAny<Guid>());
        
        //Assert
        _mockTraitRepo.Verify(x => 
            x.GetByIdAsync(It.IsAny<Guid>(), default), Times.Once);
    }
}