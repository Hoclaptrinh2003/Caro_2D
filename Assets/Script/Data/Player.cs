[System.Serializable]
public class Player
{
    public string name;
    public int wins;
    public int losses;

    public Player(string name, int wins, int losses)
    {
        this.name = name;
        this.wins = wins;
        this.losses = losses;
    }
}
