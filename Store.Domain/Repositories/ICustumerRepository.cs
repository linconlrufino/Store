using Store.Domain.Entities;

namespace Store.Domain.Repositories;

public interface ICustumerRepository
{
    Customer Get(string document);
}
