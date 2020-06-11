using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Character character;

    public PlayerData(Character _char)
    {
        character = _char;
    }
}
