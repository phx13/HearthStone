using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSShow : MonoBehaviour {
    public static VSShow vs;
    public TweenScale vsTween;
    public TweenPosition myHeroTween;
    public TweenPosition enemyHeroTween;

    void Start()
    {
        //Show("hero1", "hero6");
    }

    void Awake()
    {
        vs = this;
        //this.gameObject.SetActive(false);
    }

	public void Show(string myHeroName,string enemyHeroName)
    {
        PlayerPrefs.SetString("myHero", myHeroName);
        PlayerPrefs.SetString("enemyHero", enemyHeroName);

        BlackMask.blackmask.Show();

        myHeroTween.GetComponent<UISprite>().spriteName = myHeroName;
        enemyHeroTween.GetComponent<UISprite>().spriteName = enemyHeroName;

        vsTween.PlayForward();
        myHeroTween.PlayForward();
        enemyHeroTween.PlayForward();
    }
}
