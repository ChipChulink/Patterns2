public abstract class DeliverySystem
{
    public abstract decimal CalculateCost();
    public abstract string GetDescription();
}


public class CourierDelivery : DeliverySystem
{
    public override decimal CalculateCost()
    {
        return 10.0m;
    }

    public override string GetDescription()
    {
        return "Courier Delivery";
    }
}

public class PostalDelivery : DeliverySystem
{
    public override decimal CalculateCost()
    {
        return 5.0m;
    }

    public override string GetDescription()
    {
        return "Postal Delivery";
    }
}

public class PickupDelivery : DeliverySystem
{
    public override decimal CalculateCost()
    {
        return 0.0m; // бесплатно
    }

    public override string GetDescription()
    {
        return "Pickup";
    }
}

public class ExpressDelivery : DeliverySystem
{
    private DeliverySystem _delivery;

    public ExpressDelivery(DeliverySystem delivery)
    {
        _delivery = delivery;
    }

    public override decimal CalculateCost()
    {
        return _delivery.CalculateCost() + 15.0m;
    }

    public override string GetDescription()
    {
        return _delivery.GetDescription() + " (Express)";
    }

    public string TrackDelivery()
    {
        return $"Tracking express delivery: {_delivery.GetDescription()}";
    }
}

// Использование
class Program
{
    static void Main(string[] args)
    {
        DeliverySystem courier = new CourierDelivery();
        Console.WriteLine($"{courier.GetDescription()}: ${courier.CalculateCost()}");

        Console.WriteLine();

        DeliverySystem expressCourier = new ExpressDelivery(new CourierDelivery());
        Console.WriteLine($"{expressCourier.GetDescription()}: ${expressCourier.CalculateCost()}");
        Console.WriteLine(((ExpressDelivery)expressCourier).TrackDelivery());

        Console.WriteLine();

        DeliverySystem expressPostal = new ExpressDelivery(new PostalDelivery());
        Console.WriteLine($"{expressPostal.GetDescription()}: ${expressPostal.CalculateCost()}");
        Console.WriteLine(((ExpressDelivery)expressPostal).TrackDelivery());
    }
}