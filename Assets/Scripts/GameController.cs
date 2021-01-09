using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    GameStart,
    GamePlay,
    GameEnd
}

public class GameController : MonoBehaviour {
    public static GameController gameController;
    public GameState gameState;
    public float roundTime = 20;
    public MyCard myCard;
    public UIButton endButton;
    public UISprite rope;

    public int roundIndex = 0;
    public delegate void newRoundDelegate(string heroName);
    public event newRoundDelegate NewRoundEvent;

    private float timer = 0;
    
    private float ropelength;
    public string heroNow="myHero";
    private CardGenerate cardGenerate;

    void Awake()
    {
        gameController = this;
        //rope = this.transform.Find("rope").GetComponent<UISprite>();
        ropelength = rope.width;
        rope.width = 0;
        this.cardGenerate = this.GetComponent<CardGenerate>();
        StartCoroutine(GenerateCardForHeroNow());
    }

	// Use this for initialization
	void Start ()
    {
        gameState = GameState.GameStart;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameState==GameState.GamePlay)
        {
            timer += Time.deltaTime;
            if (roundTime-timer<=15)
            {
                rope.width = (int)(((roundTime - timer) / 15) * ropelength);
            }
            if (timer>roundTime)
            {
                NewRound();
            }
        }
	}

    public void NewRound()
    {
        if (heroNow == "myHero")
        {
            heroNow = "enemyHero";
            endButton.isEnabled = false;
        }
        else if (heroNow == "enemyHero")
        {
            heroNow = "myHero";
            endButton.isEnabled = true;
        }
        roundIndex++;
        NewRoundEvent(heroNow);
        timer = 0;
        if (roundIndex%2==0)
        {
            StartCoroutine(SupplyCard());
        }
    }

    IEnumerator SupplyCard()
    {
        if (heroNow=="myHero")
        {
            GameObject newCard = cardGenerate.RandomGenerateCard();
            yield return new WaitForSeconds(1f);
            myCard.GetCard(newCard);
        }
    }

    private IEnumerator GenerateCardForHeroNow()
    {
        yield return new WaitForSeconds(2f);

        GameObject newCard = cardGenerate.RandomGenerateCard();
        yield return new WaitForSeconds(1f);
        myCard.GetCard(newCard);

        newCard = cardGenerate.RandomGenerateCard();
        yield return new WaitForSeconds(1f);
        myCard.GetCard(newCard);

        newCard = cardGenerate.RandomGenerateCard();
        yield return new WaitForSeconds(1f);
        myCard.GetCard(newCard);

        newCard = cardGenerate.RandomGenerateCard();
        yield return new WaitForSeconds(1f);
        myCard.GetCard(newCard);

        gameState = GameState.GamePlay;
    }
}
