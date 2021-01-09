using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelect : MonoBehaviour {
    private string[] heroNames =
    {
        "吉安娜·普罗德摩尔",
        "雷克萨",
        "乌瑟尔·光明使者",
        "加尔鲁什·地狱咆哮",
        "玛法里奥·怒风",
        "古尔丹",
        "萨尔",
        "安度因·乌瑞恩",
        "瓦莉拉·萨古纳尔"
    };

    private UISprite heroSelectSprite;
    private UILabel heroSelectLabel;
    public UIButton playButton;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (playButton.isEnabled == false)
        {
            this.GetComponent<UIButton>().isEnabled = false;
        }
        else if (playButton.isEnabled == true)
        {
            this.GetComponent<UIButton>().isEnabled = true;
        }
	}

    void Awake()
    {
        heroSelectSprite = this.transform.parent.Find("heroSelect").GetComponent<UISprite>();
        heroSelectLabel = this.transform.parent.Find("SelectNameLabel").GetComponent<UILabel>();
    }

    void OnClick()
    {
        string heroname = this.gameObject.name;
        heroSelectSprite.spriteName = heroname;
        char heroIndexChar = heroname[heroname.Length - 1];
        int heroIndex = heroIndexChar - '0';
        heroSelectLabel.text = heroNames[heroIndex - 1];
    }
}
