using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoad
{
    public static void SavePlayerDataToFile(object data)
    {
        FileStream fs = new FileStream("PlayerData.dat", FileMode.Create);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, data);
        fs.Close();
    }

    public static bool DoesPlayerDataExist(string path = "PlayerData.dat")
    {
        string filename = path;

        if (File.Exists(filename))
            return true;
        else
            return false;
    }

    public static object LoadPlayerData(string path = "PlayerData.dat")
    {
        object _data;

        if(!File.Exists(path))
            return null;

        string filename = path;

        using (Stream stream = File.Open(filename, FileMode.Open))
        {
            var bformatter = new BinaryFormatter();

            try
            {
                _data = (object)bformatter.Deserialize(stream);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                stream.Close();

                Debug.Log("Corrupt Save file? Deleting. " + e);
                var stringPath = Application.dataPath + "/../";
                string directory = Path.GetFullPath(stringPath);
                File.Delete(directory + filename);

                _data = null;
            }
        }

        return (PlayerData)_data;
    }
}
