using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour {
    private UIButton endButton;
    private UILabel endLabel;
    //public GameState gameState;

    void Awake()
    {
        endButton = this.GetComponent<UIButton>();
        endLabel = transform.Find("endLabel").GetComponent<UILabel>();
    }

    public void BeClick()
    {
        if (endLabel.text=="回合结束")
        {
            endButton.isEnabled = true;
            endLabel.text = "对方回合";
            GameController.gameController.NewRound();
            GameController.gameController.rope.width = 0;
        }
        if (endLabel.text == "对方回合")
        {
            endButton.isEnabled = false;
        }
    }

    public void NewRound(string heroName)
    {
        if (heroName=="myHero")
        {
            endLabel.text = "回合结束";
        }
        else if (heroName == "enemyHero")
        {
            endLabel.text = "对方回合";
        }
    }

    // Use this for initialization
    void Start ()
    {
        GameController.gameController.NewRoundEvent += this.NewRound;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if (gameState == GameState.GamePlay&&endLabel.text=="回合结束")
        //{
        //    endButton.isEnabled = true;
        //}
    }
}
