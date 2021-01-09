using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCard : MonoBehaviour {
    public GameObject CardPrefab;
    public Transform card1;
    public Transform card2;

    private List<GameObject> myCard = new List<GameObject>();
    private float xOffset;
    private int cardDepth=3;

    public string[] cardName;

    public void GetCard(GameObject newCard=null)
    {
        GameObject myNewCard = null;
        if (newCard==null)//若没有newCard
        {
            myNewCard = NGUITools.AddChild(this.gameObject, CardPrefab);//为母体添加子物体
            myNewCard.GetComponent<UISprite>().spriteName = cardName[Random.Range(0, cardName.Length)];//随机生成一个
        }
        else
        {
            myNewCard = newCard;
            myNewCard.transform.parent = this.transform;
        }
        myNewCard.GetComponent<UISprite>().width = 120;//定义myNewCard大小
        Vector3 newPosition = card1.position + new Vector3(xOffset * myCard.Count, 0, 0);//确定位置
        iTween.MoveTo(myNewCard, newPosition, 1f);//移动到末位置时间
        myCard.Add(myNewCard);//添加新卡牌
        myNewCard.GetComponent<Card>().CardDepth(cardDepth + (myCard.Count-1)*2);//确定层数
    }

    public void LoseCard()
    {
        int index = Random.Range(0, myCard.Count);
        Destroy(myCard[index]);
        myCard.RemoveAt(index);
        UpdateShow();
    }

    public void UpdateShow()//更新显示
    {
        for (int i = 0; i < myCard.Count; i++)
        {
            Vector3 updatePosition = card1.position + new Vector3(xOffset * i, 0, 0);
            iTween.MoveTo(myCard[i], updatePosition, 0.5f);
            myCard[i].GetComponent<Card>().CardDepth(cardDepth + i * 2);
        }
    }

    public void RemoveCard(GameObject fightCard)
    {
        myCard.Remove(fightCard);
        UpdateShow();
    }

    // Use this for initialization
    void Start ()
    {
        xOffset = card2.position.x - card1.position.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
