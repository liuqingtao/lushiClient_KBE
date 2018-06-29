using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singleHeroSkillController : clientEntity {

    public Image skillImage;
    public override void updateDisplay()
    {
        base.updateDisplay();
        string index = cardID.Substring(cardID.Length - 1, 1);
        skillImage.sprite = Resources.Load<Sprite>("HeroSkill/" + index);

    }
    public override void noDis()
    {
        base.noDis();
        gameObject.SetActive(false);
    }
}
