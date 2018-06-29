using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singleFollowerController : clientEntity {

    public Image followerImage;
    public Text attText;
    public Text hpText;
    public GameObject frozenObj;
    public GameObject divineShieldObj;
    public GameObject stealthObj;
    public GameObject enableObj;
    public followerManager selfManager;

    public override void updateDisplay()
    {
        base.updateDisplay();
        followerImage.sprite = common.getCardSprite(cardID);
        attText.text = att;
        hpText.text = HP;
        frozenObj.SetActive(frozen != "0");
        divineShieldObj.SetActive(isDivineShield != "0");
        stealthObj.SetActive(isStealth != "0");
        enableObj.SetActive(isAbled != "0");
        selfManager.updateCardPostion();
    }
    public void onClick()
    {
        BFcontroller.manager.onClickEntity(this);
    }
    public override void noDis()
    {
        base.noDis();
        selfManager.removeFollower(this);
    }
}
