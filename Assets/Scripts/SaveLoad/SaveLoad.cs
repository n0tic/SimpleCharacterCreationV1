using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoad
{
    #region PlayerPrefs
    public static void SavePlayerDataPlayerPrefs(PlayerData data) {
        PlayerPrefs.SetString("CharacterName", data.character.characterName);
        PlayerPrefs.SetInt("skin", data.character.skin);
        PlayerPrefs.SetInt("head", data.character.head);
        PlayerPrefs.SetInt("top", data.character.top);
        PlayerPrefs.SetInt("pants", data.character.pants);
        PlayerPrefs.SetInt("shoes", data.character.shoes);
        PlayerPrefs.Save();
    }

    public static void RemoveSavedPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public static bool DoesPlayerPrefsExist() => PlayerPrefs.HasKey("CharacterName");

    public static PlayerData LoadPlayerDataPlayerPrefs() => new PlayerData(new Character(PlayerPrefs.GetString("CharacterName"), PlayerPrefs.GetInt("skin"), PlayerPrefs.GetInt("head"), PlayerPrefs.GetInt("top"), PlayerPrefs.GetInt("pants"), PlayerPrefs.GetInt("shoes")));
    #endregion PlayerPrefs

    #region BinarySave
    public static void SavePlayerDataToFile(object data)
    {
        FileStream fs = new FileStream("PlayerData.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, data);
        fs.Close();
    }

    public static bool DoesPlayerDataExist(string path = "PlayerData.dat") => File.Exists(path);

    public static object LoadPlayerData(string path = "PlayerData.dat")
    {
        object _data;

        if(!File.Exists(path))
            return null;

        using (Stream stream = File.Open(path, FileMode.Open))
        {
            try
            {
                var bformatter = new BinaryFormatter();
                _data = (object)bformatter.Deserialize(stream);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                stream.Close();

                Debug.Log("Corrupt Save file? Deleting. " + e);

                var stringPath = Application.dataPath + "/../";
                string directory = Path.GetFullPath(stringPath);

                if (File.Exists(directory + path))
                    File.Delete(directory + path);

                _data = null;
            }
        }

        return (PlayerData)_data;
    }

    public static bool RemoveSavedData()
    {
        string item = "PlayerData.dat";

        string directory = Path.GetFullPath(Application.dataPath + "/../");

        if (File.Exists(directory + item))
        {
            File.Delete(directory + item);
            return true;
        }

        return false;
    }
    #endregion BinarySave
}
