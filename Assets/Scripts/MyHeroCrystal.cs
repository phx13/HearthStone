using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHeroCrystal : MonoBehaviour {
    public int maxCrystal;
    public int remainCrystal;

    public UISprite[] crystals;
    private int totalCrystal;

    public UILabel myHeroCrystalLabel;

    void Awake()
    {
        totalCrystal = crystals.Length;
    }

	// Use this for initialization
	void Start ()
    {
        GameController.gameController.NewRoundEvent += this.NewRound;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ShowCrystal();
	}

    public void RefreshCrystal()
    {
        if (maxCrystal < totalCrystal)
        {
            maxCrystal++;
        }
        remainCrystal = maxCrystal;
        ShowCrystal();
    }

    public bool UseCrystal(int useNumber)
    {
        if (remainCrystal>=useNumber)
        {
            remainCrystal -= useNumber; 
            ShowCrystal();          
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ShowCrystal()
    {
        for (int i = maxCrystal; i < totalCrystal; i++)
        {
            crystals[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < maxCrystal; i++)
        {
            crystals[i].gameObject.SetActive(true);
        }
        for (int i = remainCrystal; i < maxCrystal; i++)
        {
            crystals[i].spriteName = "TextInlineImages_normal";
        }
        for (int i = 0; i < remainCrystal; i++)
        {
            int crystalName = i + 1;
            string tempStr = "";
            if (crystalName<=9)
            {
                tempStr = "0" + crystalName;
            }
            else
            {
                tempStr = "" + crystalName;
            }
            crystals[i].spriteName = "TextInlineImages_" + tempStr;    
        }
        myHeroCrystalLabel.text = remainCrystal + "/" + maxCrystal;
    }

    public void NewRound(string heroName)
    {
        if (heroName=="myHero")
        {
            if (GameController.gameController.roundIndex >= 2 && GameController.gameController.roundIndex % 2 == 0)
            {
                RefreshCrystal();
            }
        }
    }

}
