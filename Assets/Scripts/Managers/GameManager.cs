using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] PlayerData playerData;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

#if UNITY_EDITOR
        if (SaveLoad.DoesPlayerDataExist())
        {
            playerData = (PlayerData)SaveLoad.LoadPlayerData();

            if (GameObject.Find("CharacterCreation"))
            {
                GameObject.Find("CharacterCreation").GetComponent<CharacterCreation>().LoadData(playerData);
            }
        }
#endif
    }

    internal void CreateNewPlayerData(Character _char)
    {
        try
        {
            playerData = new PlayerData(_char);
#if UNITY_EDITOR
            SaveLoad.SavePlayerDataToFile(playerData);
#endif
        }
        catch (Exception)
        {
            //Leaving this blank for now...
        }

    }
}
