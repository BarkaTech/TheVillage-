namespace TheVillage;

public class Village
{
	private int food;
	private int wood;
	private int metal;
	private List<Building> buildings;
	private List<Building> projects;
	private List<Worker> workers;
	private int days;
	
	public Village() {
		food = 10;
		wood = 0;
		metal = 0;
		buildings = new List<Building>();
		projects = new List<Building>();
		workers = new List<Worker>();
		days = 0;
		
		for (int i = 0; i < 3; i++) {
			buildings.Add(new Building("House", 0, 0, 0));
		}
	}

	public delegate void AddWorkerDelegate();
	public void AddWorker(AddWorkerDelegate addWorker, String type) {
		if (workers.Count < buildings.Count) {
			workers.Add(new Worker("Worker", type, this));
			addWorker();
		}
	}
	
	// AddProject() – Adds a new building to the list of buildings to build. It should only do this if you have enough resources, and if you have, these should be deducted from your total resources.
	public void AddProject(Building building) {
		if (wood >= building.GetWoodCost() && metal >= building.GetMetalCost()) {
			wood -= building.GetWoodCost();
			metal -= building.GetMetalCost();
			projects.Add(building);
		}
	}
	
	public void AddWood() {
		wood++;
	}
	
	public void AddMetal() {
		metal++;
	}
	
	public void AddFood() {
		food += 5;
	}
	
	public void Build() {
		if (projects.Count > 0) {
			projects[0].Work();
			if (projects[0].IsFinished()) {
				buildings.Add(projects[0]);
				projects.RemoveAt(0);
			}
		}
	}
	
	public void Day() {
		foreach (Worker worker in workers) {
			worker.DoWork();
		}
		FeedWorkers();
		BuryDead();
	}
	
	public void FeedWorkers() {
		if (food >= workers.Count) {
			food -= workers.Count;
			foreach (Worker worker in workers) {
				worker.FeedWorker();
			}
		}
	}
	
	public void BuryDead() {
		for (int i = 0; i < workers.Count; i++) {
			if (!workers[i].IsAlive()) {
				workers.RemoveAt(i);
				i--;
			}
		}
		if (workers.Count == 0) {
			Console.WriteLine("Game Over");
		}
	}
	
	public int GetFood() {
		return food;
	}
	
	public int GetWood() {
		return wood;
	}
	
	public int GetMetal() {
		return metal;
	}
	
	public List<Building> GetBuildings() {
		return buildings;
	}
	
	public List<Building> GetProjects() {
		return projects;
	}
	
	public List<Worker> GetWorkers() {
		return workers;
	}
	
	public int GetDays() {
		return days;
	}

	public void SubtractFood()
	{
		food--;
	}
}

