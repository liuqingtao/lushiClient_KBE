using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerManager : MonoBehaviour {

    public float weight;
    public float height;
    public GameObject followerPrefab;
    public List<GameObject> followerList;
    private void Start()
    {
        weight = GetComponent<RectTransform>().rect.size.x/7;
        height= GetComponent<RectTransform>().rect.size.y;

    }
    public clientEntity initFollower()
    {
        GameObject obj = Instantiate(followerPrefab) as GameObject;
        followerList.Add(obj);
        obj.transform.SetParent(transform);
        obj.GetComponent<RectTransform>().sizeDelta = new Vector2(weight, height);
        updateCardPostion();
        return obj.GetComponent<singleFollowerController>();
    }
    public void updateCardPostion()
    {
        int sum = followerList.Count;
        for (int i = 0; i < sum; i++)
        {
            followerList[i].transform.position = transform.position + new Vector3(-(followerList.Count / 2.0f - i - 0.5f) * weight, 0, 0);
        }
    }
    public void removeFollower(clientEntity ce)
    {
        GameObject obj0 = null;
        foreach (GameObject obj in followerList)
        {
            if (obj.GetComponent<singleFollowerController>() == ce)
            {
                obj0 = obj;
            }
        }
        if (obj0 != null)
        {
            followerList.Remove(obj0);
            Destroy(obj0);
            updateCardPostion();
        }
        else
        {
            Debug.LogError("卡牌删除失败");
        }

    }
}
