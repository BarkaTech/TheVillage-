using System;
using System.Diagnostics;


namespace TheVillage
{ 
	class Program
	{
		static void Main(string[] args)
		{
			Village village = new Village();
			// Test if you add a worker. Then two. Then three. Assert that there are as many as there should be.
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "food");
			Debug.Assert(village.GetWorkers().Count == 1);
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "wood");
			Debug.Assert(village.GetWorkers().Count == 2);
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "build");
			Debug.Assert(village.GetWorkers().Count == 3);
			
			// Test if trying to add a worker but there are not enough houses.
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "metal");
			Debug.Assert(village.GetWorkers().Count == 3);
			
			// Test if the right thing happens if you create a new worker with a function and then call Day().
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "food");
			Debug.Assert(village.GetWorkers().Count == 3);
			village.Day();
			Debug.Assert(village.GetWorkers().Count == 3);
			
			// Try not having any workers and running Day().
			village = new Village();
			village.Day();
			Debug.Assert(village.GetWorkers().Count == 0);
			
			// Try adding some workers and running Day() while you have enough food.
			village = new Village();
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "food");
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "food");
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "food");
			village.Day();
			Debug.Assert(village.GetWorkers().Count == 3);
			
			// Test Day() but there is not enough food, make sure the right things happen.
			village = new Village();
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "metal");
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "metal");
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "metal");
			village.Day();
			Debug.Assert(village.GetFood() == 4);
			
			// Try adding a building that you can afford. Test that it works and that the right proportion of resources is drawn.
			village = new Village();
			village.AddProject(new Building("WoodMill", 3, 0, 0));
			Debug.Assert(village.GetWood() == 0);
			Debug.Assert(village.GetFood() == 10);
			Debug.Assert(village.GetMetal() == 0);
			
			
			// Try trying to add a building you can't afford and make sure it doesn't work.
			village = new Village();
			village.AddProject(new Building("WoodMill", 3, 50, 50));
			Debug.Assert(village.GetWood() == 0);
			Debug.Assert(village.GetFood() == 10);
			Debug.Assert(village.GetMetal() == 0);
			Debug.Assert(village.GetBuildings().Count == 3);
			
			// First run Day() one day before a WoodMill is ready. See that you get 1 wood first, then more wood Day() after the building is finished. The test needs a worker who makes firewood and one who builds.
			village = new Village();
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "build");
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "wood");
			village.AddProject(new Building("WoodMill", 3, 0, 0));
			village.Day();
			Debug.Assert(village.GetWood() == 1);
			village.Day();
			Debug.Assert(village.GetWood() == 2);
			village.Day();
			Debug.Assert(village.GetWood() == 3);
			village.Day();
			Debug.Assert(village.GetWood() == 4);
			
			// Do the same kind of tests for food and metal.
			village = new Village();
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "wood");
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "wood");
			village.AddProject(new Building("Farm", 0, 3, 0));
			village.Day();
			Debug.Assert(village.GetFood() == 6);
			village.Day();
			Debug.Assert(village.GetFood() == 2);
			village.AddFood();
			village.Day();
			Debug.Assert(village.GetFood() == 3);
			
			village = new Village();
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "metal");
			village.AddWorker(() => Console.WriteLine("Adding a new Worker!"), "metal");
			village.AddProject(new Building("Mine", 0, 0, 3));
			village.Day();
			Debug.Assert(village.GetMetal() == 2);
			village.Day();
			Debug.Assert(village.GetMetal() == 4);
			village.Day();
			Debug.Assert(village.GetMetal() == 6);
			village.Day();
			Debug.Assert(village.GetMetal() == 8);
			
			// Try adding a building that you can't afford and then add a building that you can afford. Make sure that the right thing happens.
			village = new Village();
			village.AddProject(new Building("WoodMill", 3, 0, 0));
			village.AddProject(new Building("Farm", 0, 3, 0));
			Debug.Assert(village.GetWood() == 0);
			Debug.Assert(village.GetFood() == 10);
			Debug.Assert(village.GetMetal() == 0);
			Debug.Assert(village.GetBuildings().Count == 3);
			
			Console.WriteLine("--------------------");
			Console.WriteLine("All tests passed!");
			Console.WriteLine("--------------------");
		}
	}
}