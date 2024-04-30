using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Datapersistencemanager : MonoBehaviour
{
    [Header("File storage configuration")]
    [SerializeField] private string filename;
    [SerializeField] private bool userecrypt;

    //Filedatahandler variable
    FileDataHandler dataHandler;

    //Variable from the Game data variables
    private GameData gameData;

    //Create a list 
    private List<Interfacedatapersistence> datapersistentobjects;

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
    // <Load game on start, save game on close>

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, filename, userecrypt);
        this.datapersistentobjects = Findalldatapersistentobjects();
        loadgame();
    }

    void OnApplicationQuit()
    {
        savegame();
    }

    // <Load game on start, save game on close>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Public methods>

    public void newgame()
    {
        this.gameData=new GameData();
    }

    public void loadgame()
    {
        //Load any saved data usign FileDataHandler
        this.gameData = dataHandler.loaddata();

        //Load any saved data, if not initialize new game
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

    public void savegame()
    {
        //Pass data to other scripts so they can update it and save data using data handler
        foreach (Interfacedatapersistence interfacedatapersistence in datapersistentobjects)
        {
            interfacedatapersistence.savedata(ref gameData);
        }

        //Save current data using the FileDataHandler
        dataHandler.savedata(gameData);


    }

    private List<Interfacedatapersistence> Findalldatapersistentobjects()
    {
        //Find all objects that implement the Interfacoe through System Linq (They must extend from Monobehavior)
        IEnumerable<Interfacedatapersistence> datapersistentobjects = FindObjectsOfType<MonoBehaviour>().
            OfType<Interfacedatapersistence>();

        //Initialize the list
        return new List<Interfacedatapersistence>(datapersistentobjects);
         
    }

}
