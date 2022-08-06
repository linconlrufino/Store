using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories;

namespace Store.Domain.Handlers;

internal class OrderHandler :
    Notifiable<Notification>,
    IHandler<CreateOrderCommand>
{

    private readonly ICustomerRepository customerRepository;
    private readonly IDeliveryFeeRepository deliveryFeeRepository;
    private readonly IDiscountRepository discountRepository;
    private readonly IProductRepository productRepository;
    private readonly IOrderRepository orderRepository;

    public OrderHandler(
        ICustomerRepository customerRepository,
        IDeliveryFeeRepository deliveryFeeRepository,
        IDiscountRepository discountRepository,
        IProductRepository productRepository,
        IOrderRepository orderRepository)
    {
        this.customerRepository = customerRepository;
        this.deliveryFeeRepository = deliveryFeeRepository;
        this.discountRepository = discountRepository;
        this.productRepository = productRepository;
        this.orderRepository = orderRepository;
    }

    public ICommandResult Handle(CreateOrderCommand command)
    {
        //Fail fast validation
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Pedido inválido", command.Notifications);


        var customer = customerRepository.Get(command.Customer);

        var deliveryFee = deliveryFeeRepository.Get(command.ZipCode);

        var discount = discountRepository.Get(command.PromoCode);

        var products = productRepository.Get(command.Items.Select(x => x.Product)).ToList();
        var order = new Order(customer, deliveryFee, discount);
        foreach (var item in command.Items)
        {
            var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
            order.AddItem(product, item.Quantity);
        }

        AddNotifications(order.Notifications);

        if (!IsValid)
            return new GenericCommandResult(false, "Falha ao gerar o pedido", Notifications);

        orderRepository.Save(order);

        return new GenericCommandResult(true, $"Pedido {order.Number} gerado com sucesso", order);
    }
}
