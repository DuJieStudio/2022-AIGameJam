using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createcard : MonoBehaviour
{
    public GameObject cardpreferb;
    public cardpool_so cardpooldata;
    public List<card_SO> cardpool;
    public List<card_SO> playercard;
    public bool isplayerturn;
    // Start is called before the first frame update
    void Start()
    {
        isplayerturn = true;
        for (int i = 0; i < 20; i++)
        {
            int x = Random.Range(0, 5);
            cardpool.Add(cardpooldata.cardpool[x]);
            
            
        }
        for (int y = 0; y< 4; y++)
        {
            drawcard();

        }

    }

    // Update is called once per frame
    void Update()
    {
        isplayerturn = GameObject.FindGameObjectWithTag("Player").GetComponent<game_control>().playerturn;
        if (isplayerturn == false)
        {
             playercard.Clear();
            for (int i = 0; i < 10; i++)
            {   if (this.transform.GetChild(i).gameObject!=null)
                    Destroy(this.transform.GetChild(i).gameObject);
            }
                
        }
        if (isplayerturn)
        {
            if (playercard.Count <4)
            {
                drawcard();
            }
        }
        if (cardpool.Count < 20)
        {
            int x = Random.Range(0, 3);
            cardpool.Add(cardpooldata.cardpool[x]);

        }
               
        

    }
    public void drawcard()
    {
        GameObject gameObject= Instantiate(cardpreferb, transform.position, transform.rotation);
        gameObject.GetComponent<Cardcontrol>().cardData = cardpool[0];
        gameObject.transform.SetParent(this.gameObject.transform,false);
        playercard.Add(cardpool[0]);
        cardpool.Remove(cardpool[0]);
    }
}
