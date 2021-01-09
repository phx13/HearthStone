using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeroCrystal : MonoBehaviour
{
    public int maxCrystal;
    public int remainCrystal;
    private int totalCrystal=10;
    public UILabel enemyHeroCrystalLabel;



    // Use this for initialization
    void Start()
    {
        GameController.gameController.NewRoundEvent += this.NewRound;
    }

    // Update is called once per frame
    void Update()
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
        if (remainCrystal >= useNumber)
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
        enemyHeroCrystalLabel.text = remainCrystal + "/" + maxCrystal;
    }

    public void NewRound(string heroName)
    {
        if (heroName == "enemyHero")
        {
            if (GameController.gameController.roundIndex >= 3 && GameController.gameController.roundIndex % 2 == 1)
            {
                RefreshCrystal();
            }
            //RefreshCrystal();
        }
    }
}