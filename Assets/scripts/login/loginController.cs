using KBEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loginController : MonoBehaviour {

    public InputField id;
    public InputField password;
    public bool autoLogin=true;
    public void login()
    {
        Debug.LogFormat("尝试登陆：用户名：{0} 密码 {1}", id.text, password.text);
        KBEngine.Event.fireIn("login", id.text, password.text, System.Text.Encoding.UTF8.GetBytes("PC"));
    }
    public void onLoginFailed(UInt16 failedcode)
    {
        Debug.LogFormat("登录失败错误码{0},原因:{1}", failedcode, KBEngineApp.app.serverErr(failedcode));
    }
    private void Start()
    {
        
        KBEngine.Event.registerOut("onLoginFailed", this, "onLoginFailed");
        KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");
        string path = Application.streamingAssetsPath;
        string idAdd = "2";
        if (path.Contains("2"))
        {

        }
        else
        {
            idAdd = "";
        }
        
        if (autoLogin == true)
        {
            KBEngine.Event.fireIn("login", "lqt01"+idAdd, "111111", System.Text.Encoding.UTF8.GetBytes("PC"));
           
        }
       
    }
    public void onLoginSuccessfully()
    {
        Debug.Log("登录成功，即将跳转到下一个场景");
        SceneManager.LoadScene(1);
    }
}
