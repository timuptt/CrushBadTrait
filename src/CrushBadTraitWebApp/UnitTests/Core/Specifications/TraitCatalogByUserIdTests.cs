using CrushBadTrait.Core.Entities;
using CrushBadTrait.Core.Secifications;
using Moq;

namespace UnitTests.Core.Specifications;

public class TraitCatalogByUserIdTests
{
    private readonly Guid _userId = Guid.NewGuid();

    [Fact]
    public void MatchesTraitUserIdWithGivenUserId()
    {
        //Arrange
        var spec = new TraitCatalogByUserIdSpecification(_userId);
        
        //Act
        var result = spec.Evaluate(GetTestTraitCollection()).FirstOrDefault();
        
        //Assert
        Assert.NotNull(result);
        Assert.Equal(_userId, result.UserId);
    }

    [Fact]
    public void MatchesNoTraitsIfIdNotPresent()
    {
        //Arrange
        var spec = new TraitCatalogByUserIdSpecification(Guid.Empty);
        
        //Act
        var result = spec.Evaluate(GetTestTraitCollection()).Any();
        
        //Assert
        Assert.False(result);
    }

    private List<Trait> GetTestTraitCollection()
    {
        return new List<Trait>()
        {
            new Trait() { UserId = Guid.NewGuid() },
            new Trait() { UserId = Guid.NewGuid() },
            new Trait() { UserId = _userId }
        };
    }
}