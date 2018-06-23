using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kzDisplayManager : MonoBehaviour {
    public Image heroImage;
    public Text kzNameText;
    public kzCardDisplayManager displayManager;
    public static kzDisplayManager manager;

    private void Awake()
    {
        manager = this;
    }
    public void setKzCardDisplay(int heroIndex,string KzName,List<uint> cardList)
    {
        heroImage.sprite = common.getHeroSprite(heroIndex, "0");
        kzNameText.text = KzName;
        displayManager.displayCardList(cardList);
    }
    private void OnGUI()
    {
        if (Input.GetKey(KeyCode.B))
        {
            setKzCardDisplay(3, "测试卡组", common.getCardIDList());
        }
        
    }
}
