namespace TheVillage;

public class Worker
{
    private string name;
    private string workType;
    private int daysHungry;
    private bool alive;
    private bool hungry;
    private Village village;
    
    public Worker(string name, string workType, Village village) {
        this.name = name;
        this.workType = workType;
        this.village = village;
        daysHungry = 0;
        alive = true;
        hungry = false;
    }
    
    public void DoWork() {
        if (alive && !hungry) {
            switch (workType) {
                case "wood":
                    village.AddWood();
                    break;
                case "metal":
                    village.AddMetal();
                    break;
                case "food":
                    village.AddFood();
                    break;
                case "build":
                    village.Build();
                    break;
            }
        }
    }
    
    public void FeedWorker() {
        if (alive) {
            village.SubtractFood();
            daysHungry = 0;
            hungry = false;
        }
    }
    
    public void Day() {
        if (alive) {
            if (hungry) {
                daysHungry++;
            }
            if (daysHungry >= 40) {
                alive = false;
            }
        }
    }
    
    public bool IsAlive() {
        return alive;
    }
    
    public bool IsHungry() {
        return hungry;
    }
    
    public string GetName() {
        return name;
    }
    
    public string GetWorkType() {
        return workType;
    }
}
