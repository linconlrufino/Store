namespace Store.Domain.Entities;

public class Customer : Entity
{
    public Customer(string name, string emai)
    {
        Name = name;
        Emai = emai;
    }

    public string Name { get; private set; }
    public string Emai { get; private set; }
}