using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getdata : MonoBehaviour
{
    public card_SO carddata;
    public Player_SO playerdata;
    public int ID
    {
        get
        {
            if (carddata != null)
            { return carddata.ID; }
            else
            { return 0; }
        }
    }
    public string name
    {
        get
        {
            if (carddata != null)
            { return carddata.name; }
            else
            { return null; }
        }
    }
    public string info
    {
        get
        {
            if (carddata != null)
            { return carddata.info; }
            else
            { return null; }
        }
    }
    public Sprite photo
    {
        get
        {
            if (carddata != null)
            { return carddata.photo; }
            else
            { return null; }
        }
    }



    public int value
    {
        get
        {
            if (carddata != null)
            { return carddata.value; }
            else
            { return 0; }
        }
    }
    public int hp
    {
        get
        {
            if (playerdata != null)
            { return playerdata.hp; }
            else
            { return 0; }
        }
    }
    public int armor
    {
        get
        {
            if (playerdata != null)
            { return playerdata.armor; }
            else
            { return 0; }
        }
    }

}
