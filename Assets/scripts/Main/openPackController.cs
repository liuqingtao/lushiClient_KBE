using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class openPackController : MonoBehaviour {
    public Text leftSum;
    public Transform[] point;
    public openPackResultDisplayController opd;

    public void openPack()
    {
        Debug.Log("请求开卡包");
        Account ME = KBEngineApp.app.player() as Account;
        if(ME != null)
        {
            ME.baseCall("reqOpenKabao");
        }
    }

    public void getOpenPackResult(List<uint> result)
    {
        Debug.Log("获取到卡包结果");
        opd.display(result);
    }
    private void OnGUI()
    {
        
        leftSum.text = "剩余卡包" + Data.kaBao.ToString();
    }
    private void Start()
    {
        KBEngine.Event.registerOut("onOpenPack", this, "getOpenPackResult");
    }

}
