using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
    public GameObject nameSetObj;
    public GameObject shopObj;
    public GameObject openPackObj;
    public static MainController main;
    public GameObject shoucangObj;
    public GameObject hkChooseObj;
    public GameObject getStringObj;

    // Use this for initialization
    private void Awake()
    {
        main = this;
    }
    void Start () {
        //控制名称设置部分的显示
        StartCoroutine(setNameDisplay());
        
    }
    public void getHeroChoose(Action<int> callback)
    {
        hkChooseObj.SetActive(true);
        heroOrKzDisplayManager.manager.initHeroDisplay(callback);
    }

    public void getString(string title,Action<string> callback)
    {
        getStringObj.SetActive(true);
        getStringManager.manager.getStringInput(title, callback);
    }
    IEnumerator setNameDisplay()
    {
        string name=Data.accountName;
        while (name == null)
        {
            yield return null;
            name = Data.accountName;
        }
        Debug.LogFormat("获取名称：【{0}】", name);
        if (name == "")
        {
            nameSetObj.SetActive(true);
        }
        else
        {
            nameSetObj.SetActive(false);
        }

    }
	
	// Update is called once per frame
	public void marchBtn()
    {
        Debug.Log("marchBtn");
    }
    public void shopBtn()
    {
        Debug.Log("shopBtn");
        shopObj.SetActive(true);
    }
    public void kabaoBtn()
    {
        Debug.Log("kabaoBtn");
        openPackObj.SetActive(true);

    }
    public void shoucangBtn()
    {
        Debug.Log("shoucangBtn");
        shoucangObj.SetActive(true);
    }
    public void taskBtn()
    {
        Debug.Log("taskBtn");
    }
}
