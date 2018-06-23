using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shoucangZhiyeDisplayController : MonoBehaviour {

    public Text zhiyeText;
    public void  chooseZhiye(int index)
    {
        Debug.LogFormat("当前选择职业：{0}", index);
        zhiyeText.text = define.HeroCareer[index];
        shoucangManager.main.setZhiyeIndex(index);
    }

}
