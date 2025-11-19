public class CharacterStyle
{
    public string Font { get; }
    public int Size { get; }
    public string Color { get; }

    public CharacterStyle(string font, int size, string color)
    {
        Font = font;
        Size = size;
        Color = color;
    }

    public void Display(char character)
    {
        Console.WriteLine($"'{character}' - Font: {Font}, Size: {Size}, Color: {Color}");
    }
}

public class StyleFactory
{
    private static Dictionary<string, CharacterStyle> _styles = new Dictionary<string, CharacterStyle>();

    public static CharacterStyle GetStyle(string font, int size, string color)
    {
        string key = $"{font}_{size}_{color}";

        if (!_styles.ContainsKey(key))
        {
            _styles[key] = new CharacterStyle(font, size, color);
        }

        return _styles[key];
    }

    public static int GetCacheSize() => _styles.Count;
}


public class Character
{
    private CharacterStyle _style;
    private char _symbol;
    private int _position;

    public Character(char symbol, int position, CharacterStyle style)
    {
        _symbol = symbol;
        _position = position;
        _style = style;
    }

    public void Display()
    {
        Console.Write($"Pos {_position}: ");
        _style.Display(_symbol);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var document = new List<Character>();

        int index = 1;
        foreach (char letter in new List<char> { 'H', 'e', 'l', 'l', 'o' })
        {
            document.Add(new Character(letter, index, StyleFactory.GetStyle("Arial", 12, "Black")));
            index++;
        }

        foreach (char letter in new List<char> { 'W', 'o', 'r', 'l', 'd' })
        {
            document.Add(new Character(letter, index, StyleFactory.GetStyle("Roboto", 14, "Blue")));
            index++;
        }
        document.Add(new Character('!', index, StyleFactory.GetStyle("Arial", 14, "Red")));


        Console.WriteLine($"\n({document.Count} characters):");
        foreach (Character character in document)
        {
            character.Display();
        }

        Console.WriteLine($"\nCreated only {StyleFactory.GetCacheSize()} style objects instead of {document.Count}");
    }
}