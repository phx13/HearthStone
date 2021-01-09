using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCard : MonoBehaviour {
    public Transform enemyCard;
    private List<GameObject> enemyCardList = new List<GameObject>();

    void AddCard(GameObject enemyNewCard)
    {
        enemyNewCard.transform.parent = this.transform;
        enemyCardList.Add(enemyNewCard);
        iTween.MoveTo(enemyNewCard, enemyCard.position, 0.5f);
    }

    void RemoveCard(GameObject enemyNewCard)
    {
        enemyCardList.Remove(enemyNewCard);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
