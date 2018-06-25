using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;
public class marchManager : MonoBehaviour {
    public Text timeText;
    float startTime=0f;
    public int choosedKzStore=-1;
    public void endMarch()
    {
        Debug.Log("结束匹配");
        Account Me = KBEngineApp.app.player() as Account;
        if (Me != null)
        {
            Me.baseCall("reqStopMarch");
        }
        gameObject.SetActive(false);
    }
    public void startMarch()
    {
        if (choosedKzStore == -1)
        {
            Debug.LogError("匹配失败没有选择卡组");
            return;
        }
        Account Me = KBEngineApp.app.player() as Account;
        if(Me != null)
        {
            Me.baseCall("reqStartMarch", choosedKzStore);
        }
    }
    private void OnEnable()
    {
        startTime = 0f;
        if (choosedKzStore == -1)
        {
            MainController.main.getKzChoose(getChoosedKz);
            
        }
        
    }

    public void getChoosedKz(int index)
    {
        startTime = Time.time;
        choosedKzStore = index;
        startMarch();
    }
    private void OnGUI()
    {
        
        if (startTime == 0f)
        {
            timeText.text="即将开始匹配:";
        }
        else
        {
            timeText.text = string.Format("当前已经匹配:{0}秒",(int)(Time.time-startTime));
        }
        
    }

}
