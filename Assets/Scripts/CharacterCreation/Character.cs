using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string characterName;

    //References kept as (int)index
    public int skin;
    public int head;
    public int top;
    public int pants;
    public int shoes;

    public Character(string name, int _skin, int _head, int _top, int _pants, int _shoes)
    {
        characterName = name;

        skin = _skin;
        head = _head;
        top = _top;
        pants = _pants;
        shoes = _shoes;
    }
}
