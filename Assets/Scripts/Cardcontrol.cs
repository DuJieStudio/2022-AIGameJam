using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
public class Cardcontrol : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public card_SO cardData;
    public int CardID;
    public int cost;
    public Text Cardname;
    public Image Cardimage;
    public Text Info;
    public Text cardcost;
    public bool ispreview;
    public bool isdragging;
    public Canvas cv;
    public Vector2 startpoint;
    public int playeraction;
    public Vector2 endpoint;
    public LayerMask enemy;
    public GameObject target;
    public game_control game_Control;
    public createcard createcard;


    public void Start()
    {
        cost = cardData.cost;
        CardID = cardData.ID;
        Cardname.text = cardData.name;
        Cardimage.sprite = cardData.photo;
        Info.text = cardData.info;
        cardcost.text = cost.ToString();
        ispreview = false;
        isdragging = false;
        transform.SetSiblingIndex(1);
        cardcost.text = cost.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ispreview = true;
        preview();

    }


    public void OnPointerExit(PointerEventData eventData)
    {
        ispreview = false;

        preview();
        startpoint = transform.position;
    }
    public void preview()
    {

        if (ispreview)
        {
            this.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            cv.sortingOrder += 100;
        }
        if (!ispreview)
        {
            this.gameObject.transform.localScale = Vector3.one;
            cv.sortingOrder -= 100;

        }
    }
    public void Update()
    {
        playeraction = GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().action;
        if (Input.GetMouseButtonUp(0) && isdragging)
        {
            
            endpoint = transform.position;
            if (Physics2D.OverlapCircle(endpoint, 5f, enemy))
            {
                Destroy(this.gameObject);
            }
            else
            {
                transform.position = startpoint;
                isdragging = false;
            }

        }
        if (isdragging)
        {
            Vector2 mousepos = Input.mousePosition;
            transform.position = new Vector2(mousepos.x, mousepos.y);
        }

    }

    public void OnBeginDrag(PointerEventData eventData)//必要端口！不能删！
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().currectaction >= cost)
            {
                isdragging = true;
                startpoint = transform.position;
            }
            else
            {
                Debug.Log("没钱还想用卡？");
            }

        }

    }

    public void OnEndDrag(PointerEventData eventData)//必要端口！不能删！
    {
    }

    public void OnDrag(PointerEventData eventData)//必要端口！不能删！
    {
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            target = collision.gameObject;
            Debug.Log(target);

        }
    }
    public void OnDestroy()
    {
        if (cardData.ID == 1)
        {
            if (isdragging)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().currectaction -= 1;
                target.GetComponent<enemy_control>().currenthp -= 5;
            }
            
        }
        if (cardData.ID == 2)
        {
            if (isdragging)
            {
                int i= GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().currectaction;
                target.GetComponent<enemy_control>().currenthp -= 5*i;
                GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().currectaction=0;
            }

        }
        if (cardData.ID == 3)
        {
            if (isdragging)
            {
                
                GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().currectaction -= 2;
                target.GetComponent<enemy_control>().currenthp += 10;
                target.GetComponent<enemy_control>().forgive += 10;
                if (target.GetComponent<enemy_control>().currenthp > target.GetComponent<enemy_control>().maxhp)
                {   
                    target.GetComponent<enemy_control>().forgive+= target.GetComponent<enemy_control>().currenthp - target.GetComponent<enemy_control>().maxhp;
                    target.GetComponent<enemy_control>().currenthp = target.GetComponent<enemy_control>().maxhp;
                   


                }
            }
        }
        if (cardData.ID == 4)
        {
            if (isdragging)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().currectaction -= 2;
                for (int i = 0; i < 2; i++)
                { GameObject.Find("grid").GetComponent<createcard>().drawcard(); }

            }
        }
        if (cardData.ID == 5)
        {
            if (isdragging)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().action += 1;
                GameObject.FindGameObjectWithTag("Player").GetComponent<fight_control>().currectaction += 1;
                
            }
        }


    }
}

