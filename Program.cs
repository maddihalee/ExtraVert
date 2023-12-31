﻿string greeting = "Welcome to MyPlants!";

Console.WriteLine(greeting);

List<Plant> plants = new List<Plant>() 
{
 new Plant()
 {
  Species = "Rose",
  LightNeeds = 4,
  AskingPrice = 12,
  City = "Rialto",
  ZIP = 92377,
  Sold = false,
  AvailableUntil = new DateTime(2023, 8, 23)
 },
  new Plant()
  {
  Species = "Daisy",
  LightNeeds = 5,
  AskingPrice = 15,
  City = "Clarksville",
  ZIP = 37040,
  Sold = true,
  AvailableUntil = new DateTime(2024, 6, 4)
  },
  new Plant()
  {
  Species = "Sunflower",
  LightNeeds = 5,
  AskingPrice = 25,
  City = "Yucaipa",
  ZIP = 92399,
  Sold = false,
  AvailableUntil = new DateTime(2022, 7, 12)
  },
  new Plant()
  {
  Species = "Hydrangea",
  LightNeeds = 3,
  AskingPrice = 200,
  City = "Atlanta",
  ZIP = 30770,
  Sold = true,
  AvailableUntil = new DateTime(2025, 2, 23)
  },
  new Plant()
  {
  Species = "Lily",
  LightNeeds = 1,
  AskingPrice = 2,
  City = "Nashville",
  ZIP = 34070,
  Sold = false,
  AvailableUntil = new DateTime(2026, 4, 13)
  }
};

Random random = new Random();

string choice = null;
while (choice != "0")
{
Console.WriteLine(@"Main Menu:
1. Display all plants
2. Post a plant to be adopted
3. Adopt a plant
4. Delist a plant
5. See plant of the day
6. Search for a plant
7. See plant stats
0. End");
choice = Console.ReadLine();

if (choice == "1")
{
  Plant chosenPlant = new Plant();
  for (int i = 0; i < plants.Count; i++)
  {
     Console.WriteLine($"A {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars. It expires on {plants[i].AvailableUntil}");
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

  Console.WriteLine("When will this plant's sale expire? Include year, press enter, month, press enter, and day as integers");
  int year = int.Parse(Console.ReadLine());
  int month = int.Parse(Console.ReadLine());
  int day = int.Parse(Console.ReadLine());

  DateTime expirationDate = new DateTime(year, month, day);
  

  Plant newPlant = new Plant
  {
    Species = Species,
    LightNeeds = LightNeeds,
    AskingPrice = AskingPrice,
    City = City,
    ZIP = ZIP,
    AvailableUntil = expirationDate
  };
  plants.Add(newPlant);
}
else if (choice == "3")
{
  Console.WriteLine("Choose a plant to buy: ");
    for (int i = 0; i < plants.Count; i++)
    {
      if (!plants[i].Sold && plants[i].AvailableUntil >= DateTime.Now)
      {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
      }
    }
    int plantIndex = int.Parse(Console.ReadLine().Trim());
    Plant selectedPlant = plants[plantIndex - 1];
    if (!selectedPlant.Sold)
    {
      selectedPlant.Sold = true;
      Console.WriteLine($"Congratulations! You have bought the {selectedPlant.Species} plant.");
    }
    else
    {
      Console.WriteLine("Invalid input. Please enter an integer.");
    }

}
else if (choice == "4")
{
  for (int i = 0; i < plants.Count; i++)
  {
    Console.WriteLine($"{i + 1}. {plants[i].Species}");
  }
    int response = int.Parse(Console.ReadLine().Trim());
   if (response >= 1 && response <= plants.Count)
   {
    plants.RemoveAt(response - 1);
    Console.WriteLine("Plant removed successfully.");
   }
   else
   {
    Console.WriteLine("Invalid input. Please enter an integer.");
   }
}
else if (choice == "5")
{
  Plant randomPlant = null;

  while (randomPlant == null || randomPlant.Sold)
  {
    int randomIndex = random.Next(0, plants.Count);
    randomPlant = plants[randomIndex];
  }
  Console.WriteLine($"A {randomPlant.Species} in {randomPlant.City} that is level {randomPlant.LightNeeds} in light needs is {randomPlant.AskingPrice} dollars");
}
else if (choice == "6")
{
  Console.WriteLine("Enter a maximum light needs number between 1 and 5: ");
  List<Plant> plantsWithLowerLightNeeds = new List<Plant>();
  int maxLightNeeds = int.Parse(Console.ReadLine().Trim());

  foreach (Plant plant in plants)
  {
    if (plant.LightNeeds <= maxLightNeeds)
    {
      plantsWithLowerLightNeeds.Add(plant);
    }
  }
  Console.WriteLine($"Plants with {maxLightNeeds} or lower: ");
  foreach (Plant plant in plantsWithLowerLightNeeds)
    {
            Console.WriteLine(plant.Species);
    }
}
else if (choice == "7")
    {
        double lowestPrice = plants.Min(plants => plants.AskingPrice);
       foreach (Plant plant in plants)
        {
            if (plant.AskingPrice == lowestPrice)
            {
                Console.WriteLine($"The plant with the lowest price is the {plant.Species} which costs {plant.AskingPrice} dollars.");
            }
        }
        double numberofPlants = plants.Count();
        Console.WriteLine($"There are {numberofPlants} plants listed currently.");

        double highestNeeds = plants.Max(plants => plants.LightNeeds);
        foreach (Plant plant in plants)
        {
            if (plant.LightNeeds ==  highestNeeds)
        {
            Console.WriteLine($"The plant with the highest light needs is the {plant.Species} with a value of {plant.LightNeeds}");
        }
       }
        int totalLightNeeds = 0;
        int numberOfPlants = plants.Count;
        foreach (Plant plant in plants)
        {
            totalLightNeeds += plant.LightNeeds;
        }
        double avgLightNeeds = (double)totalLightNeeds / numberOfPlants;
            Console.WriteLine($"The average plant's light needs is {avgLightNeeds}");
   
    }
else if (choice == "0")
{
        Console.WriteLine("See ya!");
}
else if (choice != "1" || choice != "2" || choice != "3" || choice != "4")
{
        Console.WriteLine("Please choose an existing menu item!");
}
}
