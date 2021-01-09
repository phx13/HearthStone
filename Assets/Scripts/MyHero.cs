using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHero : MonoBehaviour {
    public int maxHP = 30;
    public int minHP = 0;

    private UISprite myHero;
    private UILabel myHeroHP;
    private int HP = 30;

    void Awake()
    {
        myHero = this.GetComponent<UISprite>();
        string myHeroName = PlayerPrefs.GetString("myHero");
        myHero.spriteName = myHeroName;
        myHeroHP = this.transform.Find("myHeroHP").GetComponent<UILabel>();
    }

    public void Damage(int damage)
    {
        HP -= damage;
        myHeroHP.text = HP.ToString();
    }

    public void Cure(int cure)
    {
        HP += cure;
        myHeroHP.text = HP.ToString();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (HP<=minHP)
        {

        }
        if (HP>=maxHP)
        {
            HP = maxHP;
        }
	}
}
