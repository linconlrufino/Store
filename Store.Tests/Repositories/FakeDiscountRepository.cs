using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories;

public class FakeDiscountRepository : IDiscountRepository
{
    public Discount Get(string code)
    {
        if (code == "10OFF")
            return new Discount(10, DateTime.Now.AddDays(5));

        if (code == "20OFF")
            return new Discount(20, DateTime.Now.AddDays(-5));

        return null;
    }
}
