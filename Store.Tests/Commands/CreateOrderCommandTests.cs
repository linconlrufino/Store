using Store.Domain.Commands;

namespace Store.Tests.Commands;

public class CreateOrderCommandTests
{
    [Fact]
    [Trait("Category", "Commands")]
    public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
    {
        var command = new CreateOrderCommand();

        command.Customer = "";
        command.ZipCode = "1311080";
        command.PromoCode = "12345678";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Validate();

        Assert.False(command.IsValid);
    }
}
