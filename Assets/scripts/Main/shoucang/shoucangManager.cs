using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class shoucangManager : MonoBehaviour {
    public static shoucangManager main;

    public int page=1;
    public Text pageText;
    public List<uint> displayCardList = new List<uint>();
    public shoucangCardDisplayController scc;
    public int zhiyeIndex=0;
    public int currentZhiyeCardSum = 0;
    public GameObject kzDisplay;
    public GameObject kzCardDisplay;
    public Text BtnText;


    //状态0：卡组展示状态
    //状态1：卡组编辑状态
    public int state = 0;
    public string KzName;
    public int roleType;
    public List<uint> kzCardList = new List<uint>();
    public int indexStore;
    private void Awake()
    {
        main = this;
    }

    private void OnEnable()
    {
        changeState(0);
    }
    public void getChooseCard(uint cardID)
    {
        Debug.LogFormat("获取选择卡牌:{0}", cardID);
        if (state == 1)
        {
            if (kzCardList.Count > 29)
            {
                Debug.LogError("卡牌已经无法添加");
                return;
            }
            kzCardList.Add(cardID);
            kzDisplayManager.manager.setKzCardDisplay(roleType, KzName, kzCardList);
        }
    }
    public void changeState(int s)
    {
        if (s == 0)
        {
            kzDisplay.SetActive(true);
            kzCardDisplay.SetActive(false);
            KzName = "";
            roleType = -1;
            indexStore = -1;
            BtnText.text = "新建卡组";
            kzCardList.Clear();
            updateCardDisplay();
        }
        else
        {
            BtnText.text = "保存/退出";
            kzDisplay.SetActive(false);
            kzCardDisplay.SetActive(true);
            kzDisplayManager.manager.setKzCardDisplay(roleType, KzName, kzCardList);
        }
        state = s;
    }
    public void updateKzCardDisplay()
    {
        kzDisplayManager.manager.setKzCardDisplay(roleType, KzName, kzCardList);
    }
    public void onChangeKz()
    {
        Debug.Log("收到更新卡组通知");
        if (state == 0)
        {
            updateKzDisplay();
        }
        else
        {
            
        }
    }
    public void delCard(int index)
    {
        kzCardList.RemoveAt(index);
        updateKzCardDisplay();
    }
    public void changKz(int index)
    {
        changeState(1);
        Dictionary<string, object> dic = Data.avatarList[index];
        KzName = dic["name"].ToString();
        roleType = int.Parse(dic["roleType"].ToString());
        indexStore = index;
        kzCardList = common.obj2list(dic["cardList"]);
        setKzCard(dic);

    }
    public void delKz(int index)
    {
        Account Me = KBEngineApp.app.player() as Account;
        if(Me != null)
        {
            Me.baseCall("reqDelAvatar", index);
        }
    }
    public void clickBtn()
    {
        Debug.Log("收到点击当前状态：" + state);
        if (state == 0)
        {
            createNewKz();
        }
        else
        {
            endKzEndit();
        }
    }
    public void endKzEndit()
    {
        if (kzCardList.Count < 30)
        {
            Debug.Log("卡牌数量不足");
            return;
        }
        Account Me = KBEngineApp.app.player() as Account;
        if (Me != null)
        {
            List<object> objLs = new List<object>();
            for(int i = 0; i < kzCardList.Count; i++)
            {
                objLs.Add(kzCardList[i]);
            }

            Me.baseCall("reqChangeAvatar", roleType,objLs,KzName,indexStore);
            changeState(0);
        }
    }
    public void createNewKz()
    {
        MainController.main.getHeroChoose(getNewKzHero);
    }
    public void getNewKzHero(int heroIndex)
    {
        Debug.LogFormat("当前选择英雄：{0}", define.HeroCareer[heroIndex]);
        roleType = heroIndex;
        MainController.main.getString("请输入卡组名称", getNewKzName);

    }
    public void getNewKzName(string NewKzname)
    {
        Debug.Log("新卡组的名称：" + NewKzname);
        KzName = NewKzname;
        changeState(1);
    }

    public void updateKzDisplay()
    {
        List<Dictionary<string, object>> ls = Data.avatarList;
        Debug.LogFormat("要更新的列表长度:{0}", ls.Count);
        if (ls == null)
        {
            Debug.LogError("data.avatarList为空");
            return;
        }
        shoucangKZDisplayManager.manager.setKzDisplay(ls);
        
    }

    public void setKzCard(Dictionary<string,object> dic)
    {
        string kzName = dic["name"].ToString();
        int roleType = int.Parse(dic["roleType"].ToString());
        List<object> ls = (List<object>)dic["cardList"];
        List<uint> lsuint = new List<uint>();
        for(int i = 0; i < ls.Count; i++)
        {
            lsuint.Add(uint.Parse(ls[i].ToString()));
        }
        kzDisplayManager.manager.setKzCardDisplay(roleType, kzName, lsuint);
    }
    public void setZhiyeIndex(int index)
    {
        zhiyeIndex = index;
        updateCardDisplay();
    }
    public void setPageDisplay()
    {
        pageText.text = string.Format("第{0}页", page);
        updateCardDisplay();
    }

    public void updateCardDisplay()
    {
        List<uint> ls = new List<uint>();
        foreach(uint p in Data.cardList)
        {
            if (Data.data.card[p]["zhiye"].ToString() == zhiyeIndex.ToString())
            {
                ls.Add(p);
            }
            
        }
        List<uint> ls2 = new List<uint>();
        foreach(uint p in ls)
        {
            if (!ls2.Contains(p))
            {
                ls2.Add(p);
            }
        }
        currentZhiyeCardSum = ls2.Count;
        ls2 = sort.sortUintByCost(ls2);
        displayCardList.Clear();
        for(int i = 0; i < 8; i++)
        {
            int realIndex = i + page * 8 - 8;
            if (realIndex < ls2.Count)
            {
                displayCardList.Add(ls2[realIndex]);
            }
        }
        setCardDisplay();
        
    }
    public void setCardDisplay()
    {
        scc.displayCard(displayCardList);
    }
    public void lastPage()
    {
        if (page > 1)
        {
            page -= 1;
        }
        setPageDisplay();
    }
    public void nextPage()
    {
        if (currentZhiyeCardSum < page * 8)
        {
            return;
        }
        page += 1;
        setPageDisplay();
    }
    
    private void Start()
    {
        setPageDisplay();
    }
}
