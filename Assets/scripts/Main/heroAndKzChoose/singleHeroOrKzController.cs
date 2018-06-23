using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singleHeroOrKzController : MonoBehaviour {

    public Image hkImage;
    public Text hkText;
    public int index;

    public void click()
    {
        heroOrKzDisplayManager.manager.onClick(index);
    }
    public void setImageAndName(int heroIndex,string name)
    {
        hkImage.sprite = common.getHeroSprite(heroIndex, "0");
        hkText.text = name;
    }
    public void setIndex(int i)
    {
        index = i;
    }
}
