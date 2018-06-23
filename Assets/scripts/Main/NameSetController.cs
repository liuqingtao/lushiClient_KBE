using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class NameSetController : MonoBehaviour {

    public InputField nameInput;
    public void setName()
    {
        Debug.LogFormat("请求设置名称：{0}", nameInput.text);
        if(nameInput.text == "")
        {
            Debug.LogWarning("名称不能为空");
        }
        Account Me = KBEngineApp.app.player() as Account;
        if(Me != null)
        {
            Me.baseCall("reqChangeName", nameInput.text);
        }
        gameObject.SetActive(false);
    }
    private void Start()
    {
        
    }
}
