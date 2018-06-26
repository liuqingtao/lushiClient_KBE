using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class common : MonoBehaviour {

	public static Sprite getCardSprite(uint cardID)
    {
        Sprite spr = Resources.Load<Sprite>("card/" + cardID.ToString());
        if (spr == null)
        {
            Debug.LogFormat("getCardSprite:请求加载图标出错 id:{0}",cardID);
        }
        return spr;
    }
    public static Sprite getCardSprite(string cardID)
    {
        return getCardSprite(uint.Parse(cardID));
    }
    public static Sprite getHeroSprite(int index,string type = "")
    {

        Sprite spr = Resources.Load<Sprite>("hero/" + type+index.ToString());
        if (spr == null)
        {
            Debug.LogFormat("getHeroSprite:请求加载图标出错 id:{0} type:{1}", index,type);
        }
        return spr;
    }
    public static List<uint> getCardIDList(int sum = 30)
    {
        List<uint> ls = new List<uint>();
        for(int i = 0; i < sum; i++)
        {
            ls.Add((uint)(10000001+i));
        }
        return ls;
    }
    public static List<uint> obj2list(object obj)
    {
        List<object> ls = (List<object>)obj;
        List<uint> lsuint = new List<uint>();
        for (int i = 0; i < ls.Count; i++)
        {
            lsuint.Add(uint.Parse(ls[i].ToString()));
        }
        return lsuint;
    }
    public static string getCardDes(object cardID)
    {
        uint id = uint.Parse(cardID.ToString());
        string des = "";
        des = Data.data.card[id]["des"].ToString();
        return des;
    }
    public static string getCardName(object cardID)
    {
        uint id = uint.Parse(cardID.ToString());
        string name = "";
        name = Data.data.card[id]["name"].ToString();
        return name;
    }
}
