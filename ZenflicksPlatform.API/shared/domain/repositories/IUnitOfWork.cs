namespace zenflicks_backend.shared.domain.repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}