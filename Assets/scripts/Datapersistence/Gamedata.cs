
[System.Serializable]
public class GameData 
{
    
    public float mosttimealive;

    public float obstaclespawnrate;
    public float enemyspawnrate;
    public float enemy2spawnrate;
    // <Variables and references>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Default value in this constructor

    //Constructor
    public GameData()
    {
        //Value that is intended to be saved
        this.mosttimealive = 0;
        this.obstaclespawnrate = 10;
        this.enemyspawnrate = 15;
        this.enemy2spawnrate = 20;

    }

}
