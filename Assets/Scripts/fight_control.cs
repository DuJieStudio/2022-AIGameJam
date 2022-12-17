using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fight_control : MonoBehaviour
{
    public int hp;
    public int armor;
    public int action;
    public Player_SO playerdata;
    public Image action_image;
    public Text actiontext;
    public Slider hpbar;
    public int CreatecardNUM;

    // Start is called before the first frame update
    void Start()
    {
        hp = playerdata.hp;
        armor = playerdata.armor;
        action = playerdata.action;
        action_image = GetComponentInChildren<Image>();
        actiontext = action_image.GetComponentInChildren<Text>();
        hpbar = GetComponentInChildren<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        changedata();
    }
    public void changedata()
    {
        actiontext.text = action.ToString() + "/" + playerdata.action.ToString();
        hpbar.value = hp / playerdata.hp;
        
    }
}
