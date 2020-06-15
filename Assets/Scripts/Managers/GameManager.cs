using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public PlayerData playerData;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

#if UNITY_EDITOR && UNITY_STANDALONE
        if (SaveLoad.DoesPlayerDataExist())
        {
            playerData = (PlayerData)SaveLoad.LoadPlayerData();

            if (GameObject.Find("CharacterCreation"))
                GameObject.Find("CharacterCreation").GetComponent<CharacterCreation>().LoadData(playerData);
        }
#elif UNITY_WEBGL
        if (SaveLoad.DoesPlayerPrefsExist())
        {
            playerData = SaveLoad.LoadPlayerDataPlayerPrefs();

            if (GameObject.Find("CharacterCreation")) 
                GameObject.Find("CharacterCreation").GetComponent<CharacterCreation>().LoadData(playerData);
        }
#endif
    }

    internal void CreateNewPlayerData(Character _char)
    {
        try
        {
            playerData = new PlayerData(_char);

#if UNITY_EDITOR && UNITY_STANDALONE
                SaveLoad.SavePlayerDataToFile(playerData);
#elif UNITY_WEBGL
            SaveLoad.SavePlayerDataPlayerPrefs(playerData);
#endif
        }
        catch (Exception)
        {
            //Leaving this blank for now...
        }

    }
}
