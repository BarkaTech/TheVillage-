namespace TheVillage;

public class Building {
    private string name;
    private bool isFinished;
    private int daysToComplete;
    private int daysSpent;
    private int woodCost;
    private int metalCost;
    
    public Building(string name, int daysToComplete, int woodCost, int metalCost) {
        this.name = name;
        this.daysToComplete = daysToComplete;
        this.woodCost = woodCost;
        this.metalCost = metalCost;
        isFinished = false;
        daysSpent = 0;
    }
    
    public void Work() {
        daysSpent++;
        if (daysSpent >= daysToComplete) {
            isFinished = true;
        }
    }
    
    public bool IsFinished() {
        return isFinished;
    }
    
    public int GetWoodCost() {
        return woodCost;
    }
    
    public int GetMetalCost() {
        return metalCost;
    }
    
    public string GetName() {
        return name;
    }
}