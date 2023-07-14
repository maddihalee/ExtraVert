string greeting = "Welcome to MyPlants!";

Console.WriteLine(greeting);

List<Plant> Plants = new List<Plant>() 
{
 new Plant()
 {
  Species = "Rose",
  LightNeeds = 4,
  AskingPrice = 12,
  City = "Rialto",
  ZIP = 92377,
  Sold = false
 },
  new Plant()
  {
  Species = "Daisy",
  LightNeeds = 5,
  AskingPrice = 15,
  City = "Clarksville",
  ZIP = 37040,
  Sold = true
  },
  new Plant()
  {
  Species = "Sunflower",
  LightNeeds = 5,
  AskingPrice = 25,
  City = "Yucaipa",
  ZIP = 92399,
  Sold = false
  },
  new Plant()
  {
  Species = "Hydrangea",
  LightNeeds = 3,
  AskingPrice = 200,
  City = "Atlanta",
  ZIP = 30770,
  Sold = true
  },
  new Plant()
  {
  Species = "Lily",
  LightNeeds = 1,
  AskingPrice = 2,
  City = "Nashville",
  ZIP = 34070,
  Sold = false
  }
};

string choice = null;
while (choice != "0")
{
Console.WriteLine(@"Main Menu:
1. Display all plants
2. Post a plant to be adopted
3. Adopt a plant
4. Delist a plant
0. End");
choice = Console.ReadLine();

if (choice == "1")
{
  Plant chosenPlant = new Plant();
  for (int i = 0; i < Plants.Count; i++)
  {
     Console.WriteLine($"A {Plants[i].Species} in {Plants[i].City} {(Plants[i].Sold ? "was sold" : "is available")} for {Plants[i].AskingPrice} dollars.");
  }
}
else if (choice == "2")
{
  Console.WriteLine($"Enter the species name: ");
  string Species = Console.ReadLine();
  Console.WriteLine($"Enter the plant's light needs on a scale of 1-5");
  int LightNeeds = int.Parse(Console.ReadLine().Trim());
  Console.WriteLine($"List the plant's asking price: ");
  int AskingPrice = int.Parse(Console.ReadLine().Trim());
  Console.WriteLine($"List the city it's located in: ");
  string City = Console.ReadLine();
  Console.WriteLine($"What is the ZIP Code of that city?");
  int ZIP = int.Parse(Console.ReadLine().Trim());
  Plant newPlant = new Plant
  {
    Species = Species,
    LightNeeds = LightNeeds,
    AskingPrice = AskingPrice,
    City = City,
    ZIP = ZIP
  };
  Plants.Add(newPlant);
}
else if (choice == "3")
{
  throw new NotImplementedException("Adopt a plant");
}
else if (choice == "4")
{
  throw new NotImplementedException("Delist a plant");
}
else if (choice == "0")
{
  Console.WriteLine("See ya!");
}
else if (choice != "1" || choice != "2" || choice != "3" || choice != "4" || choice != "5")
{
  Console.WriteLine("Please choose an existing menu item!");
}
}
