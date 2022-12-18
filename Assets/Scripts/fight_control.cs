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
    public int currectaction;
    public bool isforgive;

    // Start is called before the first frame update
    void Start()
    {
        hp = playerdata.hp;
        armor = playerdata.armor;
        action = playerdata.action;
        currectaction = action;
        action_image = GetComponentInChildren<Image>();
        actiontext = action_image.GetComponentInChildren<Text>();
        hpbar = GetComponentInChildren<Slider>();
        isforgive = false;


    }

    // Update is called once per frame
    void Update()
    {
        addaction();
        changedata();
    }
    public void changedata()
    {
        actiontext.text = currectaction.ToString() + "/" + action.ToString();
        float a = hp;
        float b = playerdata.hp;

        hpbar.value = a / b;
        
    }
    public void addaction()
    
    {
        if (GetComponent<game_control>().playerturn == false)
        {
            if (action > 5)
            {
                action = 5;
            }
            currectaction = action+1;
        }
        
    }
    public void isbeginingforgive()
    {
        isforgive = true;
        
    }
}
