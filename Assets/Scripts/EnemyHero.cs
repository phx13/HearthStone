using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHero : MonoBehaviour {
    public int maxHP = 30;
    public int minHP = 0;

    private UISprite enemyHero;
    private UILabel enemyHeroHP;
    private int HP = 30;

    void Awake()
    {
        enemyHero = this.GetComponent<UISprite>();
        string enemyHeroName = PlayerPrefs.GetString("enemyHero");
        enemyHero.spriteName = enemyHeroName;
        enemyHeroHP = this.transform.Find("enemyHeroHP").GetComponent<UILabel>();
    }

    public void Damage(int damage)
    {
        HP -= damage;
        enemyHeroHP.text = HP.ToString();
    }

    public void Cure(int cure)
    {
        HP += cure;
        enemyHeroHP.text = HP.ToString();
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (HP <= minHP)
        {

        }
        if (HP >= maxHP)
        {
            HP = maxHP;
        }
    }
}
