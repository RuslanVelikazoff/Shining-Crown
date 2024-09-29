public class GameData
{
    public int crystal;

    public bool[] purchasedKnight = new bool[4];
    public bool[] selectedKnight = new bool[4];

    public bool purchasedShield;
    public bool purchasedSphere;

    public bool[] achievementComplete = new bool[3];

    public bool[] levelUnlock = new bool[8];
    public bool[] levelCompleted = new bool[8];
    
    public GameData()
    {
        crystal = 0;

        purchasedKnight[0] = true;
        purchasedKnight[1] = false;
        purchasedKnight[2] = false;
        purchasedKnight[3] = false;

        selectedKnight[0] = true;
        selectedKnight[1] = false;
        selectedKnight[2] = false;
        selectedKnight[3] = false;

        purchasedShield = false;
        purchasedSphere = false;

        achievementComplete[0] = false;
        achievementComplete[1] = false;
        achievementComplete[2] = false;

        levelUnlock[0] = true;
        levelUnlock[1] = false;
        levelUnlock[2] = false;
        levelUnlock[3] = false;
        levelUnlock[4] = false;
        levelUnlock[5] = false;
        levelUnlock[6] = false;
        levelUnlock[7] = false;

        levelCompleted[0] = false;
        levelCompleted[1] = false;
        levelCompleted[2] = false;
        levelCompleted[3] = false;
        levelCompleted[4] = false;
        levelCompleted[5] = false;
        levelCompleted[6] = false;
        levelCompleted[7] = false;
    }
}
