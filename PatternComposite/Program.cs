
public class Program
{
    public static void Main(string[] args)
    {
        Box box1 = new Box(10);

        Box box2 = new Box(2);
        box2.AddProduct(new Product("Яблоко", 15));
        box2.AddProduct(new Product("Груша", 20));
        box2.AddProduct(new Product("Банан", 30));

        Box box3 = new Box(1);
        box3.AddProduct(new Product("Торт", 100));

        box1.InsertBox(box2);
        box1.InsertBox(box3);

        Console.WriteLine(box1.BoxCost);
        Console.WriteLine(box2.BoxCost);
        Console.WriteLine(box3.BoxCost);
    }

}

public class Box
{
    private int size;
    public int Size => size;

    private int boxCost;
    public int BoxCost => boxCost;

    private List<Box> nestedBoxes;
    private List<Product> products;

    public Box(int size)
    {
        nestedBoxes = new List<Box>();
        products = new List<Product>();
        this.size = size;
    }

    public void InsertBox(Box newBox)
    {
        if (newBox.Size >= size)
        {
            Console.WriteLine("Не удалось поместить коробку (размер коробки слишком мал)");
            return;
        }
        nestedBoxes.Add(newBox);
        boxCost += newBox.BoxCost;
    }
    public void AddProduct(Product product)
    {
        if (nestedBoxes.Count > 0)
        {
            Console.WriteLine("Не удалось поместить продукт (В коробке лежат другие коробки)");
        }
        products.Add(product);
        boxCost += product.Cost;
    }
}

public class Product
{
    private string name;
    private int cost;
    public int Cost => cost;

    public Product(string name, int cost)
    {
        this.name = name;
        this.cost = cost;
    }
}