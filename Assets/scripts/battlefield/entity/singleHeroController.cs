using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class singleHeroController : clientEntity {

    public Image heroImage;
    public Text attText;
    public Text hpText;
    public Text armorText;
    public override void updateDisplay()
    {
        base.updateDisplay();
        heroImage.sprite = common.getCardSprite(cardID);
        attText.text = att;
        hpText.text = HP;
        armorText.text = armor;

        GetComponent<Outline>().enabled = (isAbled == "1");
    }
    public override void noDis()
    {
        base.noDis();
        gameObject.SetActive(false);
    }
    public void onClick()
    {
        BFcontroller.manager.onClickEntity(this);
    }
}
