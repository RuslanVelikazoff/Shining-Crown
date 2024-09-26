public class GameData
{
    public int crystal;

    public bool[] purchasedKnight = new bool[4];
    public bool[] selectedKnight = new bool[4];

    public bool purchasedShield;
    public bool purchasedSphere;
    
    public GameData()
    {
        crystal = 1200;

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
    }
}
