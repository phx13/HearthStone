using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    private UISprite myCard;
    private UILabel hpLabel;
    private UILabel damageLabel;
    public int needCrystal;

    private string myCardName
    {
        get
        {
            return myCard.spriteName;
        }
    }

    void Awake()
    {
        myCard = this.GetComponent<UISprite>();
        hpLabel = this.transform.Find("hpLabel").GetComponent<UILabel>();
        damageLabel = this.transform.Find("damageLabel").GetComponent<UILabel>();
    }

    void OnHover(bool isOver)
    {
        if (isOver)
        {
            DescribeCard.gameObjectCard.ShowCard(myCardName);
        }
    }

    public void CardDepth(int depth)
    {
        myCard.depth = depth;
        hpLabel.depth = depth+1;
        damageLabel.depth = depth+1;
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        hpLabel.text = myCard.spriteName[9] - '0' + "";
        damageLabel.text = myCard.spriteName[7] - '0' + "";
        needCrystal = myCard.spriteName[5]-'0';
    }
}
