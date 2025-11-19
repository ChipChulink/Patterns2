public interface IRoad
{
    string Name { get; }
}

public abstract class Transport
{
    public abstract void Ride(IRoad road);
}
public class Road : IRoad
{
    public string Name { get; }

    public Road(string name)
    {
        Name = name;
    }
}

public class Car : Transport
{
    public string Model { get; }

    public Car(string model)
    {
        Model = model;
    }

    public override void Ride(IRoad road)
    {
        Console.WriteLine($"Car '{Model}' is driving on road '{road.Name}'");
    }
}

public class Donkey
{
    public string Name { get; }

    public Donkey(string name)
    {
        Name = name;
    }

    public void Eat()
    {
        Console.WriteLine($"Donkey '{Name}' is eating");
    }
}

public class Saddle : Transport
{
    private Donkey _donkey;

    public Saddle(Donkey donkey)
    {
        _donkey = donkey;
    }

    public override void Ride(IRoad road)
    {
        Console.WriteLine($"Donkey '{_donkey.Name}' with saddle is riding on road '{road.Name}'");
        _donkey.Eat();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var highway = new Road("Highway");
        var dirtRoad = new Road("Dirt Road");

        var car = new Car("Toyota");
        var donkey = new Donkey("Snail");
        var saddle = new Saddle(donkey);

        var transports = new List<Transport> { car, saddle };

        foreach (var transport in transports)
        {
            transport.Ride(highway);
            transport.Ride(dirtRoad);

            Console.WriteLine();
        }
    }
}