using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerManagerMain : MonoBehaviour {

    public static followerManagerMain manager;
    public followerManager[] followerManagers;
    private void Awake()
    {
        manager = this;
    }
    public void getRenderObj(bool isSelf, SceneEntityObject obj)
    {
        if (isSelf)
        {
            followerManagers[0].getRenderObj(obj);
        }
        else
        {
            followerManagers[1].getRenderObj(obj);
        }
    }
}
