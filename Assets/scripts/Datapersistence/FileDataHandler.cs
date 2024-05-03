using UnityEngine;
using System;
using System.IO;

public class FileDataHandler 
{

    //Initialize file path
    private string datadirectorypath = "";

    //Initialize file name
    private string datadirectoryname = "";

    //Variables for encryption
    private bool userecrypt=false;
    private readonly string codeword = "parallelepiped";

    // <Private Variables>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Constructor>

    //Constructor for the 3 private variables
    public FileDataHandler(string directorypath, string directoryname, bool userecrypt)
    {
        this.datadirectorypath = directorypath;
        this.datadirectoryname = directoryname;
        this.userecrypt = userecrypt;
    }

    // <Constructor>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Methods>

    public void savedata(GameData gameData)
    {
        string fullpath= Path.Combine(datadirectorypath, datadirectoryname);
        
        try
        {
            //Create directory in case it doesnt exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullpath));

            //Serialize the Csharp game data into Json string
            string datatosstore = JsonUtility.ToJson(gameData, true);

            //Encrypt data before saving
            if (userecrypt)
            {
                datatosstore = encryptdecryptdatafile(datatosstore);
            }

            //Write the file to the system
            using (FileStream stream= new FileStream(fullpath, FileMode.Create))
            {
                using(StreamWriter writer= new StreamWriter(stream))
                {
                    writer.Write(datatosstore);
                }
            }
        } 
        catch (Exception e)
        {
            Debug.LogError("Error ocurred, there was a problem saving the file: "+ fullpath+"\n"+e);
        }
    }

    public GameData loaddata()
    {
        string fullpath = Path.Combine(datadirectorypath, datadirectoryname);
        GameData loadeddata=null;
        
        if (File.Exists(fullpath))
        {
            try
            {
                //Load serialized data from file
                string datatoload = "";
                using (FileStream stream =new FileStream(fullpath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        datatoload = reader.ReadToEnd();
                    } 
                }

                //Decrypt data before loading
                if (userecrypt)
                {
                    datatoload = encryptdecryptdatafile(datatoload);
                }

                //Deserialize data from Json to Csharp once read
                loadeddata = JsonUtility.FromJson<GameData>(datatoload);


            }
            catch (Exception e)
            {
                Debug.LogError("Error ocurred while trying to load data from file: " + fullpath + "\n" + e);
            }
        }

        return loadeddata;
    }

    private string encryptdecryptdatafile(string data)
    {
        string moddata = "";
        for (int i=0; i<data.Length; i = i + 1)
        {
            moddata = moddata + (char) (data[i] ^ codeword[i % codeword.Length]);
        }

        return moddata;
    }

}
