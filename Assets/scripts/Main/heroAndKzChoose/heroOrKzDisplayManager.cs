using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heroOrKzDisplayManager : MonoBehaviour {
    public List<GameObject> hkList=new List<GameObject>();
    public GameObject hkPrefab;
    public static heroOrKzDisplayManager manager;
    public Image heroImage;
    public Text heroName;
    public int indexStore;
    public int state = 0; //0 选英雄 1 选卡组
    public Action<int> callbackStore;
    private void Awake()
    {
        manager = this;
    }
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        indexStore = -1;
        callbackStore = null;
    }
    
    public void okBtn()
    {
        Debug.Log("选择英雄完成,当前选择："+ define.HeroCareer[indexStore]);
        
        if(indexStore == -1)
        {
            Debug.Log("未选择英雄，仍为-1");
            return;
        }
        callbackStore(indexStore);
        MainController.main.hkChooseObj.SetActive(false);
    }

    public void onClick(int index)
    {
        int heroIndex = index;
        if (state == 1)
        {
            heroIndex = int.Parse(Data.avatarList[index]["roleType"].ToString());
        }
        heroImage.sprite = common.getHeroSprite(heroIndex);
        heroName.text = define.HeroCareer[heroIndex];
        indexStore = index;
    }
    public void setActiveSum(int sum)
    {
        if (sum > 9) sum = 9;
        Debug.LogFormat("更新hk数量：{0}", sum);
        while (hkList.Count < sum)
        {
            GameObject obj = Instantiate(hkPrefab) as GameObject;
            obj.transform.SetParent(transform);
            hkList.Add(obj);
        }
        while (hkList.Count > sum)
        {
            GameObject obj = hkList[hkList.Count - 1];
            hkList.Remove(obj);
            Destroy(obj);
        }
        for (int i = 0; i < hkList.Count; i++)
        {
            hkList[i].GetComponent<singleHeroOrKzController>().setIndex(i);
        }
    }
    public void initHeroDisplay(Action<int> callback)
    {
        Debug.Log("初始化英雄选择界面");
        state = 0;
        setActiveSum(9);
        for(int i = 0; i < 9; i++)
        {
            hkList[i].GetComponent<singleHeroOrKzController>().setImageAndName(i, define.HeroCareer[i]);
        }
        callbackStore = callback;
    }
    public void initKzDisplay(Action<int> callback)
    {
        Debug.Log("初始化卡组选择界面");
        state = 1;

        int kzSum = Data.avatarList.Count;
        if (kzSum > 9) kzSum = 9;
        setActiveSum(kzSum);
        List<Dictionary<string, object>> ls = Data.avatarList;
        for(int i = 0; i < kzSum; i++)
        {
            string kzName = ls[i]["name"].ToString();
            int roleType = int.Parse(ls[i]["roleType"].ToString());
            hkList[i].GetComponent<singleHeroOrKzController>().setImageAndName(roleType, kzName);
        }
        callbackStore = callback;
    }

}
