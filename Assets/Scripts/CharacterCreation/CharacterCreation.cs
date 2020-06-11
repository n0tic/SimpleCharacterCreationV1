using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCreation : MonoBehaviour
{
    [SerializeField] string ReferenceSaver; //This does absolutely nothing. This is only to trick GIT.

    [Header("UI References")]
    [SerializeField] TMP_InputField charnameField;
    [SerializeField] Image skinsHolder;
    int skinIndex = 0;
    [SerializeField] Image headsHolder;
    int headsIndex = 0;
    [SerializeField] Image topsHolder;
    int topsIndex = 0;
    [SerializeField] Image pantsHolder;
    int pantsIndex = 0;
    [SerializeField] Image shoesHolder;
    int shoesIndex = 0;

    [Header("Sprite Resources")]
    [SerializeField] List<Sprite> skins;
    [SerializeField] List<Sprite> heads;
    [SerializeField] List<Sprite> tops;
    [SerializeField] List<Sprite> pants;
    [SerializeField] List<Sprite> shoes;

    

    private void Awake()
    {
        if (skinsHolder.sprite == null)
            skinsHolder.color = new Color(0, 0, 0, 0);

        if (headsHolder.sprite == null)
            headsHolder.color = new Color(0, 0, 0, 0);

        if (topsHolder.sprite == null)
            topsHolder.color = new Color(0, 0, 0, 0);

        if (pantsHolder.sprite == null)
            pantsHolder.color = new Color(0, 0, 0, 0);

        if (shoesHolder.sprite == null)
            shoesHolder.color = new Color(0, 0, 0, 0);
    }

    internal void LoadData(PlayerData playerData)
    {
        skinIndex = playerData.character.skin;
        skinsHolder.sprite = skins[skinIndex];

        headsIndex = playerData.character.head;
        headsHolder.sprite = heads[headsIndex];

        topsIndex = playerData.character.top;
        topsHolder.sprite = tops[topsIndex];

        pantsIndex = playerData.character.pants;
        pantsHolder.sprite = pants[pantsIndex];

        shoesIndex = playerData.character.shoes;
        shoesHolder.sprite = shoes[shoesIndex];

        charnameField.text = playerData.character.characterName;
    }

    public void CycleSkinForward(bool status)
    {
        if(status)
        {
            if (skinIndex == skins.Count - 1)
                skinIndex = -1;

            if (skinIndex < skins.Count - 1)
            {
                skinIndex++;
                skinsHolder.sprite = skins[skinIndex];
            }
        }
        else
        {
            skinsHolder.color = new Color(1, 1, 1, 1);

            if (skinIndex == 0)
                skinIndex = skins.Count - 1;

            if (skinIndex > 0)
            {
                skinIndex--;
                skinsHolder.sprite = skins[skinIndex];
            }
        }

        if (skinsHolder.sprite == null)
            skinsHolder.color = new Color(0, 0, 0, 0);
        else
            skinsHolder.color = new Color(1, 1, 1, 1);
    }

    public void CycleHeadForward(bool status)
    {
        if (status)
        {
            if (headsIndex == heads.Count - 1)
                headsIndex = -1;

            if (headsIndex < heads.Count - 1)
            {
                headsIndex++;
                headsHolder.sprite = heads[headsIndex];
            }
        }
        else
        {
            if (headsIndex == 0)
                headsIndex = heads.Count - 1;

            if (headsIndex > 0)
            {
                headsIndex--;
                headsHolder.sprite = heads[headsIndex];
            }
        }

        if (headsHolder.sprite == null)
            headsHolder.color = new Color(0, 0, 0, 0);
        else
            headsHolder.color = new Color(1, 1, 1, 1);
    }

    public void CycleTopForward(bool status)
    {
        if (status)
        {
            if (topsIndex == tops.Count - 1)
                topsIndex = -1;

            if (topsIndex < tops.Count - 1)
            {
                topsIndex++;
                topsHolder.sprite = tops[topsIndex];
            }
        }
        else
        {
            if (topsIndex == 0)
                topsIndex = tops.Count - 1;

            if (topsIndex > 0)
            {
                topsIndex--;
                topsHolder.sprite = tops[topsIndex];
            }
        }

        if (topsHolder.sprite == null)
            topsHolder.color = new Color(0, 0, 0, 0);
        else
            topsHolder.color = new Color(1, 1, 1, 1);
    }

    public void CyclePantsForward(bool status)
    {
        if (status)
        {
            if (pantsIndex == pants.Count - 1)
                pantsIndex = -1;

            if (pantsIndex < pants.Count - 1)
            {
                pantsIndex++;
                pantsHolder.sprite = pants[pantsIndex];
            }
        }
        else
        {
            if (pantsIndex == 0)
                pantsIndex = pants.Count - 1;

            if (pantsIndex > 0)
            {
                pantsIndex--;
                pantsHolder.sprite = pants[pantsIndex];
            }
        }

        if (pantsHolder.sprite == null)
            pantsHolder.color = new Color(0, 0, 0, 0);
        else
            pantsHolder.color = new Color(1, 1, 1, 1);
    }

    public void CycleShoesForward(bool status)
    {
        if (status)
        {
            if (shoesIndex == shoes.Count - 1)
                shoesIndex = -1;

            if (shoesIndex < shoes.Count - 1)
            {
                shoesIndex++;
                shoesHolder.sprite = shoes[shoesIndex];
            }
        }
        else
        {
            if (shoesIndex == 0)
                shoesIndex = shoes.Count - 1;

            if (shoesIndex > 0)
            {
                shoesIndex--;
                shoesHolder.sprite = shoes[shoesIndex];
            }
        }

        if (shoesHolder.sprite == null)
            shoesHolder.color = new Color(0, 0, 0, 0);
        else
            shoesHolder.color = new Color(1, 1, 1, 1);
    }

    public void CreateCharacter()
    {
        if (charnameField.text != string.Empty && charnameField.text.Length > 2)
        {
            GameManager.instance.CreateNewPlayerData(new Character(charnameField.text, skinIndex, headsIndex, topsIndex, pantsIndex, shoesIndex));
        }
        else
            Debug.LogError("You need to have a name and it needs to be minimum 3 letters. Ex \"Kim\"");
    }
}
