using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Datapersistencemanager : MonoBehaviour
{

    //Get instance publicly but to modify it would need to be privately only in this class
    public static Datapersistencemanager instance { get; private set; }
    //Create a list 
    private List<Interfacedatapersistence> datapersistentobjects;

    //Variable from the Game data to keep track of the current data
    private GameData gameData;

    [Header("File storage configuration")]
    [SerializeField] private string filename;
    [SerializeField] private bool userecrypt;
    //Filedatahandler variable
    private FileDataHandler dataHandler;

    // <Variables and references>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Get the instance publicly>

    //Check if there is more than 1 data persistence manager
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than 1 data persistence Manager in scene");
        }
        instance = this;
    }


    // <Get the instance publicly>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Load game on start, get the list of all persistent objects and save game on close>

    //On start, initialize data handler, list of objects that implement interface and load saved data
    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, filename, userecrypt);
        this.datapersistentobjects = Findalldatapersistentobjects();
        loadgame(); //Can be used in buttons
    }

    //Method to find all objects in the scene that implement the interface
    private List<Interfacedatapersistence> Findalldatapersistentobjects()
    {
        //Find all objects that implement the Interfacoe through System Linq (They must extend from Monobehavior)
        IEnumerable<Interfacedatapersistence> datapersistentobjects = FindObjectsOfType<MonoBehaviour>().
            OfType<Interfacedatapersistence>();

        //Initialize the list
        return new List<Interfacedatapersistence>(datapersistentobjects);

    }

    //Method to save data once app is exited
    private void OnApplicationQuit()
    {
        savegame(); //Can be used in buttons 
    }

    // <Load game on start, save game on close>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Public methods>

    //Create new game data
    public void newgame()
    {
        this.gameData=new GameData();
    }

    //Load existing game data and if non-existent, use newgame() method
    public void loadgame()
    {
        //Load any saved data using FileDataHandler
        this.gameData = dataHandler.loaddata(); //in case data handler does exist then gameData=null

        //If not initialized new game
        if (this.gameData == null)
        {
            Debug.Log("No saved data found. Initialize to default values");
            newgame();
        }

        //Push loaded data to all scripts that need it
        foreach (Interfacedatapersistence interfacedatapersistence in datapersistentobjects)
        {
            interfacedatapersistence.loaddata(gameData);
        }

    }

    //Save current game data
    public void savegame()
    {
        //Extract data to other scripts so they can update it and save data using data handler
        foreach (Interfacedatapersistence interfacedatapersistence in datapersistentobjects)
        {
            interfacedatapersistence.savedata(ref gameData);
        }

        //Save current data using the FileDataHandler
        dataHandler.savedata(gameData);


    }

}
