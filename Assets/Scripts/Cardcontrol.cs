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
            if (playeraction >= cost)
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
        { target = collision.gameObject; }
    }
    public void OnDestroy()
    {
        if (cardData.ID == 0)
        {
            
        }
        if (cardData.ID == 1)
        {

        }
        if (cardData.ID == 2)
        {
            
        }

        
    }
}

