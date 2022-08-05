using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Tests.Queries;

public class ProductQueriesTests
{
    private IList<Product> products;

    public ProductQueriesTests()
    {
        products = new List<Product>();

        products.Add(new Product("Produto 01", 10, true));
        products.Add(new Product("Produto 02", 20, true));
        products.Add(new Product("Produto 03", 30, true));
        products.Add(new Product("Produto 04", 40, false));
        products.Add(new Product("Produto 05", 50, false));
    }

    [Fact]
    [Trait("Category", "Queries")]
    public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3()
    {
        var result = products.AsQueryable().Where(ProductQueries.GetActiveProducts());

        Assert.Equal(3, result.Count());
    }

    [Fact]
    [Trait("Category", "Queries")]
    public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2()
    {
        var result = products.AsQueryable().Where(ProductQueries.GetInactiveProducts());

        Assert.Equal(2, result.Count());
    }
}
