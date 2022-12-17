using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="card",menuName ="createnewcard")]
public class card_SO : ScriptableObject
{
    public int ID;
    public string name;
    public string info;
    public Sprite photo;
    public int value;
    public int cost;
     

}
