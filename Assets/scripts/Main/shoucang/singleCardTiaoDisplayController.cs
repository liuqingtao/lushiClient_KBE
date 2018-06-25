using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singleCardTiaoDisplayController : MonoBehaviour {
    public Image cardImage;
    public Text cardName;
    public int index;
    public void setCardTiao(uint cardID)
    {
        cardImage.sprite = common.getCardSprite(cardID);
        cardName.text = Data.data.card[cardID]["name"].ToString();
    }
    private void OnGUI0()
    {
        if (Input.GetKey(KeyCode.G))
        {
            setCardTiao((uint)10000003);
        }
    }
    public void setIndex(int i)
    {
        index = i;
    }
    public void click()
    {
        Debug.Log("click id"+index);
        shoucangManager.main.delCard(index);
    }
	
}
