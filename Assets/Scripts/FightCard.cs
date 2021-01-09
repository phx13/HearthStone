using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCard : MonoBehaviour {
    private List<GameObject> fightCardList = new List<GameObject>();
    public Transform fightCard1;
    public Transform fightCard2;
    private float xOffset;

    public void AddCard(GameObject fightCard)
    {
        fightCard.transform.parent = this.transform;
        fightCardList.Add(fightCard);
        Vector3 newPosition = GetPosition();
        iTween.MoveTo(fightCard, newPosition, 0.5f);
    }

    Vector3 GetPosition()
    {
        int index = fightCardList.Count;
        if (index % 2 == 0)
        {
            Vector3 position = fightCard1.position + new Vector3(xOffset * (index / 2), 0, 0);
            return position;
        }
        else
        {
            Vector3 position = fightCard1.position - new Vector3(xOffset * (index / 2), 0, 0);
            return position;
        }

    }

    // Use this for initialization
    void Start ()
    {
        xOffset = fightCard2.position.x - fightCard1.position.x;	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
