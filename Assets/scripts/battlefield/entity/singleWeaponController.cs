using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class singleWeaponController : clientEntity {
    public Image weaponImage;
    public Text attText;
    public Text hpText;
    public Text nameText;

    public override void updateDisplay()
    {
        base.updateDisplay();
        weaponImage.sprite = common.getCardSprite(cardID);
        attText.text = att;
        hpText.text = HP;
        nameText.text = common.getCardName(cardID);
    }
    public override void noDis()
    {
        base.noDis();
        gameObject.SetActive(false);
    }
    private void Start()
    {
        noDis();
    }

}
