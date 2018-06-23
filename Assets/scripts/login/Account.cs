namespace KBEngine
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using KBEngine;

    public class Account : Entity
    {
        public override void __init__()
        {
            base.__init__();
            Debug.Log("登陆成功 已经创建Account实体");
            KBEngine.Event.fireOut("onLoginSuccessfully");
        }
        public void onOpenPack(object obj)
        {
            List<object> resultList = (List<object>)obj;
            List<uint> rels = new List<uint>();
            foreach(object p in resultList)
            {
                rels.Add(uint.Parse(p.ToString()));
            }
            KBEngine.Event.fireOut("onOpenPack", rels);
        }
        public void set_Name(object obj)
        {
            Debug.LogFormat("获取角色名称：{0}", getDefinedProperty("Name"));
            KBEngine.Event.fireOut("set_Name", getDefinedProperty("Name"));
        }
        public void set_Gold(object obj)
        {
            Debug.LogFormat("获取角色金币：{0}", getDefinedProperty("Gold"));
            KBEngine.Event.fireOut("set_Gold", getDefinedProperty("Gold"));
        }
        public void set_Kabao(object obj)
        {
            Debug.LogFormat("获取角色卡包：{0}", getDefinedProperty("Kabao"));
            KBEngine.Event.fireOut("set_Kabao", getDefinedProperty("Kabao"));
        }
        public void set_CardList(object obj)
        {
            Debug.LogFormat("获取角色CardList：{0}", getDefinedProperty("CardList"));
            KBEngine.Event.fireOut("set_CardList", getDefinedProperty("CardList"));
        }
        public void set_AvatarList(object obj)
        {
            Debug.LogFormat("获取角色CardList：{0}", getDefinedProperty("AvatarList"));
            KBEngine.Event.fireOut("set_AvatarList", getDefinedProperty("AvatarList"));
        }

    }

}

