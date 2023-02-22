using System;
using System.Collections.Generic;

SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();
string[] inputData = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);

while (inputData[0] != "Revision")
{
    string shopName = inputData[0];
    string productName = inputData[1];
    double productPrice = double.Parse(inputData[2]);

    if (!shops.ContainsKey(shopName))
    {
        shops.Add(
            shopName, 
            new Dictionary<string, double>()
            {
                { productName, productPrice }
            });
    }
    else
    {
        shops[shopName].Add(productName, productPrice);
    }


    inputData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
}

foreach (var shop in shops)
{
    Console.WriteLine($"{shop.Key}->");
    foreach (var product in shop.Value)
    {
        Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
    }
}