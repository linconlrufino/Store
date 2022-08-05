using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    public class FakeCustomerRepository : ICustumerRepository
    {
        public Customer Get(string document)
        {
            if (document == "12345678911")
                return new Customer("Tolstoi", "tolstoi@tst.com");

            return null;
        }
    }
}
