public class UserDatabase
{
    public void SaveUser(string user)
    {
        Console.WriteLine($"User saved: {user}");
    }
}

public class OrderDatabase
{
    public void SaveOrder(string order)
    {
        Console.WriteLine($"Order saved: {order}");
    }
}

public class DatabaseGateway
{
    private UserDatabase _userDb = new UserDatabase();
    private OrderDatabase _orderDb = new OrderDatabase();

    public void SaveData(string user, string order)
    {
        _userDb.SaveUser(user);
        _orderDb.SaveOrder(order);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var gateway = new DatabaseGateway();
        gateway.SaveData("Ivan", "Order1");
    }
}