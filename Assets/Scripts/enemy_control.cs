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

    public  void Start()
    {
        maxhp = enemydata.hp;
        currenthp = maxhp;
        forgive = 0;
        forgivedata = GetComponentInChildren<Text>();


        
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
    }


    public void changedata()
    {
       
        forgivedata.text = forgive.ToString();
    }
    public void caniforgive()
    {
        int i = Random.Range(0, 100);
        if (i < forgive)
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
