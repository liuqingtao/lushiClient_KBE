using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singleCardController : clientEntity {
    public override void updateDisplay()
    {
        base.updateDisplay();
        GetComponent<cardDisplayController>().crystal.text = cost;
        GetComponent<cardDisplayController>().att.text = att;
        GetComponent<cardDisplayController>().hp.text = HP;
        GetComponent<cardDisplayController>().cardName.text = common.getCardName(cardID);
        GetComponent<cardDisplayController>().des.text = common.getCardDes(cardID);
        GetComponent<cardDisplayController>().kapaitupian.sprite = common.getCardSprite(cardID);
    }
    public override void noDis()
    {
        base.noDis();
        cardManager.manager.removeCard(this);
    }
    public void onDrag()
    {
        transform.position = Input.mousePosition;
    }
    public void endDrag()
    {
        float y = cardManager.manager.useCardPoint.position.y;
        if(transform.position.y >= y)
        {
            Debug.Log("出牌");
            if ((common.getCardProperty(cardID, "needTarget")) == "0")
            {
                reqUse(0);
            }
            else
            {
                BFcontroller.manager.getUseTarget(this);
            }
        }
    }
}
