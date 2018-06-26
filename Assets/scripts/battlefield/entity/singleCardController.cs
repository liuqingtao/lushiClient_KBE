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
}
