using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescribeCard : MonoBehaviour {
    public static DescribeCard gameObjectCard;
    private UISprite describeCard;
    private float timer;
    private float showTime = 3;
    private bool isShow = false;
    private UILabel hpLabel;
    private UILabel damageLabel;

    void Awake()
    {
        hpLabel = this.transform.Find("hpLabel").GetComponent<UILabel>();
        damageLabel = this.transform.Find("damageLabel").GetComponent<UILabel>();
        gameObjectCard = this;
        describeCard= this.GetComponent<UISprite>();
        describeCard.alpha = 0;
    }

    public void ShowCard(string describeCardName)
    {
        this.gameObject.SetActive(true);
        describeCard.spriteName = describeCardName;
        describeCard.alpha = 1;
        isShow = true;
        hpLabel.text = describeCardName[9] - '0' + "";
        damageLabel.text = describeCardName[7] - '0' + "";
        timer = 0;
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isShow)
        {
            timer += Time.deltaTime;
            if (timer>=showTime)
            {
                describeCard.alpha = 0;
                isShow = false;
                timer = 0;
            }
            else
            {
                describeCard.alpha = ((showTime - timer) / showTime);
            }
        }
	}
}
