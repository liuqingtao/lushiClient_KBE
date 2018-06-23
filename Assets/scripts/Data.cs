using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;

public class Data : MonoBehaviour {

    public static Data data;
    public static string accountName;
    public static int gold;
    public static int kaBao;
    public static List<uint> cardList;
    public static List<Dictionary<string, object>> avatarList =new List<Dictionary<string, object>>();
    public Dictionary<uint, Dictionary<string, object>> card=new Dictionary<uint, Dictionary<string, object>>();
    private void Awake()
    {
        if(data != null)
        {
            Destroy(gameObject);
            return;

        }
        data = this;
        DontDestroyOnLoad(gameObject);
    }
    public void set_Name(object obj)
    {
        Debug.LogFormat("修改储存的名称 原名称：{0}  新名称{1}",accountName,obj.ToString());
        accountName = obj.ToString();
    }
    public void set_Gold(object obj)
    {
        Debug.LogFormat("修改储存的金币数量：{0}  新金币数量{1}", gold, obj.ToString());
        gold =int.Parse(obj.ToString());
    }
    public void set_Kabao(object obj)
    {
        Debug.LogFormat("修改储存的卡包数量：{0}  新卡包数量{1}", kaBao, obj.ToString());
        kaBao = int.Parse(obj.ToString());
    }
    public void set_CardList(object obj)
    {
        Debug.LogFormat("修改CardList：");
        List<object> cl = (List<object>)obj;
        foreach(object p in cl)
        {
            cardList.Add(uint.Parse(p.ToString()));
        }
        foreach(uint pp in cardList)
        {
           // Debug.Log(pp.ToString());
        }
    }
    public void set_AvatarList(object obj)
    {
        List<object> ls1 = (List<object>)obj;
        avatarList.Clear();
        for(int i=0;i < ls1.Count; i++)
        {
            Dictionary<string, object> dic = (Dictionary<string, object>)ls1[i];
            avatarList.Add(dic);

        }
        Debug.LogFormat("set_avatarList 长度:{0}",avatarList.Count);
        if(shoucangManager.main != null)
        {
            if (shoucangManager.main.isActiveAndEnabled)
            {
                shoucangManager.main.onChangeKz();
            }
        }
    }
    private void Start()
    {
        KBEngine.Event.registerOut("set_Name", this, "set_Name");
        KBEngine.Event.registerOut("set_Gold", this, "set_Gold");
        KBEngine.Event.registerOut("set_Kabao", this, "set_Kabao");
        KBEngine.Event.registerOut("set_CardList", this, "set_CardList");
        KBEngine.Event.registerOut("set_AvatarList", this, "set_AvatarList");
        loadResources();
        cardList = new List<uint>();
    }
    public void loadResources()
    {
        string cardStr = "";
        cardStr = Resources.Load<TextAsset>("d_card_dis.py.datas").text;
        Debug.Log(cardStr);
        JsonData cardJson = JsonToDictionary(cardStr);
        foreach(string key in cardJson.Keys)
        {
            Dictionary<string, object> cardDic = new Dictionary<string, object>();
            JsonData dic2 = cardJson[key.ToString()];
            foreach(string key2 in dic2.Keys)
            {
                cardDic.Add(key2, dic2[key2]);
            }
            cardDic.Add("sum", 0);
            card.Add(Convert.ToUInt32(key.ToString()),cardDic);
        }
        foreach(uint key in card.Keys)
        {
            //Debug.Log(key);
            foreach(string key2 in card[key].Keys)
            {
                //Debug.Log(key2.ToString() + ":" + card[key][key2]);
            }
        }
    }
    private JsonData JsonToDictionary(string Data)
    {
        try
        {
            return JsonMapper.ToObject(Data);
        }
        catch(Exception ex)
        {
            throw new System.Exception(ex.Message); 
        }
    }
}
