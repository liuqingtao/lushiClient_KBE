using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class ShopController : MonoBehaviour {
    public InputField buySum;
    public void Buy()
    {
        Debug.LogFormat("购买数量：{0}", buySum.text);
        string i = buySum.text;
        int a = 0;
        if(int.TryParse(i,out a) == false)
        {
            Debug.LogError("不是数字 重新输入");
            buySum.text = "";
            return;
        }
        else
        {
            if (a <= 0)
            {
                Debug.LogError("输入的数字不合法 重新输入");
                buySum.text = "";
                return;
            }
            else
            {
                buyKabao(a);
            }

        }
    }
    void buyKabao(int sum)
    {
        Debug.Log("卡包购买通过，数量：" + sum);
        Account ME = KBEngineApp.app.player() as Account;
        if(ME !=null)
        {
            ME.baseCall("reqBuyKabao", sum);
        }
    }
	
}
