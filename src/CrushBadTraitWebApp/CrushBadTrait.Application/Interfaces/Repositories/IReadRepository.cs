using Ardalis.Specification;

namespace CrushBadTrait.Core.Interfaces.Repositories;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot { }