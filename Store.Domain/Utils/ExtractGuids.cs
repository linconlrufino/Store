using Store.Domain.Commands;

namespace Store.Domain.Utils;

public static class ExtractGuids
{
    public static IEnumerable<Guid> Extract(IList<CreateOrderItemCommand> items)
    {
        return items.Select(x => x.Product);
    }
}
