using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardManager : MonoBehaviour {

    public GameObject cardPrefab;
    public List<GameObject> cardList = new List<GameObject>();
    public Transform[] areaPoint;
    public Transform useCardPoint;
    public float xOffset;
    public static cardManager manager;

    private void Awake()
    {
        manager = this;
    }
    private void Start()
    {
        xOffset = (areaPoint[1].position.x - areaPoint[0].position.x)/9;
 
    }
    public void updateCardPostion()
    {
        
        for(int i = 0; i < cardList.Count; i++)
        {
            cardList[i].transform.position = areaPoint[0].position + new Vector3(xOffset * i, 0, 0);
            
        }
    }
    public clientEntity initCard()
    {

        GameObject obj = Instantiate(cardPrefab) as GameObject;
        cardList.Add(obj);
        obj.transform.SetParent(transform);
        updateCardPostion();
        return obj.GetComponent<singleCardController>();
    }
    public void getRenderObj(bool isSelf,SceneEntityObject obj)
    {
        if (isSelf)
        {
            obj.getRenderObj(initCard());
        }
    }
    public void removeCard(clientEntity scc)
    {
        GameObject obj0=null;
        foreach(GameObject obj in cardList)
        {
            if(obj.GetComponent<singleCardController>() == scc)
            {
                obj0 = obj;
            }
        }
        if(obj0 != null)
        {
            cardList.Remove(obj0);
            Destroy(obj0);
            updateCardPostion();
        }
        else
        {
            Debug.LogError("卡牌删除失败");
        }
        
    }
   
              
    
}
