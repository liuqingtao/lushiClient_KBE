using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoucangKZDisplayManager : MonoBehaviour {

    public RectTransform content;
    public GameObject kzPrefab;
    float high;
    public List<GameObject> kzList = new List<GameObject>();
    public static shoucangKZDisplayManager manager;
    private void Awake()
    {
        manager = this;
    }
    private void Start()
    {
        high = kzPrefab.GetComponent<RectTransform>().sizeDelta.y;
        Debug.LogFormat("获取到Kzprefab高度{0}",high);
    }
    public void setKZSum(int sum)
    {
        Debug.LogFormat("设置显示{0}个卡组",sum);
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, high * sum);
        while (kzList.Count < sum)
        {
            GameObject obj = Instantiate(kzPrefab) as GameObject;
            obj.transform.SetParent(transform);
            kzList.Add(obj);
        }
        while (kzList.Count > sum)
        {
            GameObject obj = kzList[kzList.Count - 1];
            kzList.Remove(obj);
            Destroy(obj);
        }
        for (int i = 0; i < kzList.Count; i++)
        {
            kzList[i].GetComponent<singleKZController>().setIndex(i);
        }
    }
    public void setKzDisplay(List<Dictionary<string, object>> ls)
    {
        setKZSum(ls.Count);
        for(int i = 0; i < ls.Count; i++)
        {
            singleKZController skc = kzList[i].GetComponent<singleKZController>();
            string kzName = ls[i]["name"].ToString();
            int roleType = int.Parse(ls[i]["roleType"].ToString());
            skc.setKZ(roleType, kzName);
        }
    }
    private void OnGUI0()
    {
        if (Input.GetKey(KeyCode.J))
        {
            setKZSum(10);
        }
    }
}
