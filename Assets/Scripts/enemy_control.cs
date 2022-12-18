using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_control : MonoBehaviour
{
    public int currenthp;
    public int maxhp;
    public int forgive;
    public enemy_so enemydata;
    public Text forgivedata;
    public bool isforgive;
    public Slider hp;

    public  void Start()
    {
        maxhp = enemydata.hp;
        currenthp = maxhp;
        forgive = 0;
        forgivedata = GetComponentInChildren<Text>();
        hp = GetComponentInChildren<Slider>();


        
    }
    public void Update()
    {
        changedata();
        if (currenthp <= 0)
        {
            Destroy(this.gameObject);
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().isforgive == true)
        {
            caniforgive();
           
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<game_control>().playerturn == false)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().hp -= 5;
        }
    }


    public void changedata()
    {
       
        forgivedata.text = forgive.ToString();
        float x = currenthp;
        float y = maxhp;
        hp.value =  x/y;
    }
    public void caniforgive()
    {
        if (Random.Range(0, 100) < forgive)
        { isforgive = true; }
        else
        { 
            forgive -= 5;  Debug.Log("¿íË¡Ê§°Ü");
            GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().isforgive = false;
        }
        if (isforgive)
        {
            Destroy(this.gameObject);
        }
    }
}
