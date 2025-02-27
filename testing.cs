using System;
using System.Collections.Generic;

class Potato
{
    public string Type { get; set; }
    public string Color { get; set; }
    public int Weight { get; set; } // Weight in grams

    public Potato(string type, string color, int weight)
    {
        Type = type;
        Color = color;
        Weight = weight;
    }

    public void PrintPotato()
    {
        Console.WriteLine($"Type: {Type}, Color: {Color}, Weight: {Weight}g");
    }
}

class Program
{
    static void Main()
    {
        List<Potato> potatoes = new List<Potato>
        {
            new Potato("Russet", "Brown", 300),
            new Potato("Yukon Gold", "Yellow", 250),
            new Potato("Red Bliss", "Red", 200),
            new Potato("Fingerling", "Purple", 150)
        };

        foreach (var potato in potatoes)
        {
            potato.PrintPotato();
        }
    }
}
