using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistroyCards : MonoBehaviour {
    public Transform cardIn;
    public Transform cardOut;
    public Transform card1;
    public Transform card2;
    public GameObject cardPrefab;

    private List<GameObject> cardList = new List<GameObject>();
    private float yOffset;

    // Use this for initialization
    void Start () {
        yOffset = card2.position.y - card1.position.y;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public IEnumerator AddCards()
    {
        GameObject newCard = GameObject.Instantiate(cardPrefab, cardIn.position, Quaternion.identity) as GameObject;
        yield return 0;
        newCard.transform.position = cardIn.position;

        iTween.MoveTo(newCard, card1.position, 0.5f);
        if (cardList.Count>=6)
        {
            iTween.MoveTo(cardList[0], cardOut.position, 0.5f);
            Destroy(cardList[0], 0.5f);
            cardList.RemoveAt(0);
        }
        for (int i = 0; i < cardList.Count; i++)
        {
            iTween.MoveTo(cardList[i], cardList[i].transform.position + new Vector3(0, yOffset, 0), 0.5f);
        }
        cardList.Add(newCard);
    }

}
