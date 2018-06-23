using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class getStringManager : MonoBehaviour {
    public InputField strIF;
    public Text titleText;
    public static getStringManager manager;
    public Action<string> callbackStore;
    private void Awake()
    {
        manager = this;
    }

    private void OnEnable()
    {
        strIF.text = "";
        titleText.text = "";
        callbackStore = null;
    }
    public void getStringInput(string title,Action<string> callback)
    {
        titleText.text = title;
        callbackStore = callback;
    }

    public void okBtn()
    {
        if (strIF.text == "")
        {
            Debug.Log("输入为空，请重新输入");
            return;
        }
        callbackStore(strIF.text);
        gameObject.SetActive(false);
    }
	
}
