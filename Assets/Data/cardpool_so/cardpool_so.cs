using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="cardpool",menuName ="creatnewpool")]
public class cardpool_so : ScriptableObject
{
    public List<card_SO> cardpool =new List<card_SO>();
}
