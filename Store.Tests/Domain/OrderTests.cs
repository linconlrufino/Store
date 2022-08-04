using Store.Domain.Entities;

namespace Store.Tests.Domain
{

    public class OrderTests
    {
        [Fact]
        [Trait("Category", "Domain")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            var customer = new Customer("Vader", "vader@deathstar.com");
            var deliveryFee = 15;
            var discount = new Discount(0, DateTime.Now);
            var newOrder = new Order(customer, deliveryFee, discount);
            var orderNumberLenght = newOrder.Number.Length;

            Assert.Equal(orderNumberLenght, 8);
        }

        [Fact]
        [Trait("Category", "Domain")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
        {
            Assert.True(false);
        }

        [Fact]
        [Trait("Category", "Domain")]
        public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
        {
            Assert.True(false);
        }

        [Fact]
        [Trait("Category", "Domain")]
        public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
        {
            Assert.True(false);
        }

        [Fact]
        [Trait("Category", "Domain")]
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
        {
            Assert.True(false);
        }

        [Fact]
        [Trait("Category", "Domain")]
        public void Dado_um_novo_item_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado()
        {
            Assert.True(false);
        }

        [Fact]
        [Trait("Category", "Domain")]
        public void Dado_um_novo_pedido_valido_seu_total_deve_ser_50()
        {
            Assert.True(false);
        }

        [Fact]
        [Trait("Category", "Domain")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
        {
            Assert.True(false);
        }

        [Fact]
        [Trait("Category", "Domain")]
        public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_60()
        {
            Assert.True(false);
        }

        [Fact]
        [Trait("Category", "Domain")]
        public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_50()
        {
            Assert.True(false);
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
}