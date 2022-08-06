using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repositories;
using Store.Tests.Repositories;

namespace Store.Tests.Handlers;

public class OrderHandlerTests
{
    private readonly ICustomerRepository customerRepository;
    private readonly IDeliveryFeeRepository deliveryFeeRepository;
    private readonly IDiscountRepository discountRepository;
    private readonly IProductRepository productRepository;
    private readonly IOrderRepository orderRepository;

    public OrderHandlerTests()
    {
        customerRepository = new FakeCustomerRepository();
        deliveryFeeRepository = new FakeDeliveryFeeRepository();
        discountRepository = new FakeDiscountRepository();
        orderRepository = new FakeOrderRepository();
        productRepository = new FakeProductRepository();
    }


    [Fact]
    [Trait("Category", "Handlers")]
    public void Dado_um_cliente_inexistente_o_pedido_nao_deve_ser_gerado()
    {
        Assert.True(false);
    }

    [Fact]
    [Trait("Category", "Handlers")]
    public void Dado_um_cep_invalido_o_pedido_deve_ser_gerado_normalmente()
    {
        Assert.True(false);
    }


    [Fact]
    [Trait("Category", "Handlers")]
    public void Dado_um_promocode_inexistente_o_pedido_deve_ser_gerado_normalmente()
    {
        Assert.True(false);
    }

    [Fact]
    [Trait("Category", "Handlers")]
    public void Dado_um_pedido_sem_itens_o_mesmo_nao_deve_ser_gerado()
    {
    }

    [Fact]
    [Trait("Category", "handlers")]
    public void Dado_um_comando_valido_o_pedido_deve_ser_gerado()
    {
        var command = new CreateOrderCommand();

        command.Customer = "12345678911";
        command.ZipCode = "13110803";
        command.PromoCode = "12345678";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

        var handler = new OrderHandler(
            customerRepository,
            deliveryFeeRepository,
            discountRepository,
            productRepository,
            orderRepository);

        handler.Handle(command);

        Assert.True(command.IsValid);
    }
}
