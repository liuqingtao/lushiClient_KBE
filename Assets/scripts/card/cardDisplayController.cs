using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardDisplayController : MonoBehaviour {
    public Text crystal;
    public Text att;
    public Text hp;
    public Text cardName;
    public Text des;
    public Image kapaitupian;
    public uint cardIdStore;
    public void setCard(uint cardID)
    {
        Dictionary<string, object> cardDic = new Dictionary<string, object>();
        if(!Data.data.card.TryGetValue(cardID,out cardDic))
        {
            Debug.LogError("卡牌数据获取失败 id:" + cardID);
            return;
        }
        crystal.text = cardDic["cost"].ToString();
        att.text = cardDic["att"].ToString();
        hp.text = cardDic["HP"].ToString();
        cardName.text = cardDic["name"].ToString();
        des.text = cardDic["des"].ToString();
        kapaitupian.sprite = Resources.Load<Sprite>("card/" + cardID.ToString());
        cardIdStore = cardID;
    }
    private void Start()
    {
        
    }
   
}
