using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class game_control : MonoBehaviour
{
    public int time;
    public bool playerturn;
    public void Awake()
    {
        time = 1;
        playerturn = true;
    }
    public void Start()
    {
    }
    void Update()
    {

        if (playerturn == false)
        {
            enemyendturn();
            GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().action+=1;
            playerturn = true;

        }
        if (GameObject.FindGameObjectWithTag("enemy") == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 4)
            { Application.Quit(); }
            else
            { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
            
            
        }

        
    }
    public void playerendturn()
    {
        playerturn = false;
    }
    public void enemyendturn()
    {
        time += 1;
        

    }
}
