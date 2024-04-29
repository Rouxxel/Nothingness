using UnityEngine;

public class Datapersistencemanager : MonoBehaviour
{

    private GameData gameData;

    // <Variables and references>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Get the instance publicly>
    public static Datapersistencemanager Instance { get; private set; }

    //Check if there is more than 1 data persistence manager
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than 1 data persistence Manager in scene");
        }
        Instance = this;
    }


    // <Get the instance publicly>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Public methods>

    public void newgame()
    {
        this.gameData=new GameData();
    }

    public void loadgame()
    {
        //Load any saved data, if not initialize new game
        if (this.gameData == null)
        {
            Debug.Log("No saved data found. Initialize to default values");
            newgame();
        } else
        {
            //Push loaded data to all scripts that need it
            
        }

    }

    public void savegame()
    {
        //Pass data to other scripts so they can update it and save data using data handler
    }

}
