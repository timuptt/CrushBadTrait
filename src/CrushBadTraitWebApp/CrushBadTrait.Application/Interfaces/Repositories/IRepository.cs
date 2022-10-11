using Ardalis.Specification;

namespace CrushBadTrait.Core.Interfaces.Repositories;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot { }