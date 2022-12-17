using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="enemydata",menuName ="")]
public class enemy_so : ScriptableObject
{
    public int ID;
    public string enemyname;
    public int hp;
    public int forgive;
    public int attack;
   
}
