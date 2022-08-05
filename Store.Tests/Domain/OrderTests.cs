using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Domain;

public class OrderTests
{
    private Customer customer;
    private Product product;
    private Discount discount;

    public OrderTests()
    {
        customer = new Customer("Vader", "vader@deathstar.com");
        product = new Product("Produto", 10, true);
        discount = new Discount(10, DateTime.Now.AddDays(5));
    }

    [Fact]
    [Trait("Category", "Domain")]
    public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
    {
        var order = new Order(customer, 0, discount);

        var orderNumberLength = order.Number.Length;

        Assert.Equal(8, orderNumberLength);
    }

    [Fact]
    [Trait("Category", "Domain")]
    public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
    {
        var order = new Order(customer, 0, discount);

        Assert.Equal(EOrderStatus.WaitingPayment, order.Status);
    }

    [Fact]
    [Trait("Category", "Domain")]
    public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
    {
        var order = new Order(customer, 0, discount);

        order.AddItem(product, 2);

        order.Pay(10);

        Assert.Equal(EOrderStatus.WaitingDelivery, order.Status);
    }

    [Fact]
    [Trait("Category", "Domain")]
    public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
    {
        var order = new Order(customer, 0, discount);

        order.Cancel();

        Assert.Equal(EOrderStatus.Canceled, order.Status);
    }

    [Fact]
    [Trait("Category", "Domain")]
    public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
    {
        var order = new Order(customer, 0, discount);

        order.AddItem(null, 2);

        Assert.Empty(order.Items);
    }

    [Fact]
    [Trait("Category", "Domain")]
    public void Dado_um_novo_item_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado()
    {
        var order = new Order(customer, 0, discount);

        order.AddItem(product, 0);
        order.AddItem(product, -2);

        Assert.Empty(order.Items);
    }

    [Fact]
    [Trait("Category", "Domain")]
    public void Dado_um_novo_pedido_valido_seu_total_deve_ser_50()
    {
        var order = new Order(customer, 10, discount);

        order.AddItem(product, 5);

        Assert.Equal(50, order.Total());
    }

    [Fact]
    [Trait("Category", "Domain")]
    public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
    {
        var expiredDiscount = new Discount(5,DateTime.Now.AddDays(-5));
        var order = new Order(customer, 10, expiredDiscount);

        order.AddItem(product, 5);

        Assert.Equal(60, order.Total());
    }

    [Fact]
    [Trait("Category", "Domain")]
    public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_60()
    {
        var order = new Order(customer, 10, null);

        order.AddItem(product, 5);

        Assert.Equal(60, order.Total());
    }

    [Fact]
    [Trait("Category", "Domain")]
    public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_50()
    {
        var order = new Order(customer, 10, discount);

        order.AddItem(product, 5);

        Assert.Equal(50, order.Total());
    }

    [Fact]
    [Trait("Category", "Domain")]
    public void Dado_uma_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_60()
    {
        Assert.True(false);
    }

    [Fact]
    [Trait("Category", "Domain")]
    public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
    {
        Assert.True(false);
    }
}
