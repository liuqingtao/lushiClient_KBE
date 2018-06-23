using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singleKZController : MonoBehaviour {
    public Image heroImage;
    public Text desText;
    public int index;
    public void setIndex(int i)
    {
        index = i;
    }
    public void setKZ(int heroIndex,string kzName)
    {
        Debug.LogFormat("刷新卡组显示，所需英雄序号：{0},卡组名称{1}", heroIndex, kzName);
        heroImage.sprite = Resources.Load<Sprite>("hero/0" + heroIndex.ToString());
        desText.text = kzName;
    }
    private void OnGUI0()
    {
        if (Input.GetKey(KeyCode.I))
        {
            setKZ(2, "测试卡组名称");
        }
    }
    public void change()
    {
        Debug.LogFormat("请求更新卡组序号：{0}", index);
        shoucangManager.main.changKz(index);
    }
    public void delete()
    {
        Debug.LogFormat("请求删除卡组序号：{0}", index);
        shoucangManager.main.delKz(index);
    }
	
}
