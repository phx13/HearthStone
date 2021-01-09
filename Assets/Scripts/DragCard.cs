using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCard : UIDragDropItem {
    
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if (surface!=null&&surface.tag=="fightArea")
        {
            int needCrystal = this.GetComponent<Card>().needCrystal;
            MyHeroCrystal myHeroCrystal = GameObject.Find("myHeroCrystal").GetComponent<MyHeroCrystal>();

            UIButton endButton = GameObject.Find("endButton").GetComponent<UIButton>();
            if (endButton.isEnabled&&needCrystal<=myHeroCrystal.remainCrystal)
            {
                myHeroCrystal.UseCrystal(needCrystal);
                this.transform.parent.GetComponent<MyCard>().RemoveCard(this.gameObject);
                surface.GetComponent<FightCard>().AddCard(this.gameObject);
            }
            else
            {
                transform.parent.GetComponent<MyCard>().UpdateShow();
            }
        }
        else
        {
            transform.parent.GetComponent<MyCard>().UpdateShow();
        }      
    }
}
