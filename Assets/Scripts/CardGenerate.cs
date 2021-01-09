using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerate : MonoBehaviour {

    public GameObject cardPrefab;
    public Transform cardBegin;
    public Transform cardEnd;
    public List<string> cardNames;

    private UISprite newCardSprite;

    public float transformTime = 1f;//变换时间
    private float timer = 0;//计时器
    public int transformSpeed = 10;//变换速度
    private bool isTransforming = false;

    public GameObject RandomGenerateCard()
    {
        GameObject newCard = NGUITools.AddChild(this.gameObject, cardPrefab);//为母体创建子物体
        newCard.transform.position = cardBegin.position;//子物体的初始位置
        iTween.MoveTo(newCard, cardEnd.position, 1f);//运动到末位置
        newCardSprite = newCard.GetComponent<UISprite>();
        isTransforming = true;
        return newCard;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isTransforming)//如果在变换
        {
            timer += Time.deltaTime;//时间增加
            int index = (int)(timer / (1f / transformSpeed));
            index %= cardNames.Count;//取得数组的值
            newCardSprite.spriteName = cardNames[index];//确定sprite名字
            if (timer > transformTime)
            {
                string cardNowName = cardNames[Random.Range(0, cardNames.Count)];//随机生成一个名字
                newCardSprite.spriteName = cardNowName;//赋值给新的子物体
                cardNames.Remove(cardNowName);//从牌库里去掉该牌
                isTransforming = false;
                timer = 0;
            }
        }
    }
}
