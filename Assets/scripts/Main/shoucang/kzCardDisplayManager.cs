using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kzCardDisplayManager : MonoBehaviour
{

    public RectTransform content;
    public GameObject cardTiaoPrefab;
    float high;
    public List<GameObject> cardList = new List<GameObject>();
    private void Start()
    {
        high = cardTiaoPrefab.GetComponent<RectTransform>().sizeDelta.y;
        Debug.LogFormat("获取到cardTiaoPrefab高度{0}", high);
    }
    public void displayCardList(List<uint> cardIdList)
    {
        setCardSum(cardIdList.Count);
        for(int i = 0; i < cardList.Count; i++)
        {
            cardList[i].GetComponent<singleCardTiaoDisplayController>().setCardTiao(cardIdList[i]);
        }
    }
    public void setCardSum(int sum)
    {
        Debug.LogFormat("设置显示{0}个卡条", sum);
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, high * sum);
        while (cardList.Count < sum)
        {
            GameObject obj = Instantiate(cardTiaoPrefab) as GameObject;
            obj.transform.SetParent(transform);
            cardList.Add(obj);
        }
        while (cardList.Count > sum)
        {
            GameObject obj = cardList[cardList.Count - 1];
            cardList.Remove(obj);
            Destroy(obj);
        }
        for(int i = 0; i < cardList.Count; i++)
        {
            cardList[i].GetComponent<singleCardTiaoDisplayController>().setIndex(i);
        }
    }
    private void OnGUI()
    {
        if (Input.GetKey(KeyCode.I)){
            setCardSum(30);
        }

    }
}
