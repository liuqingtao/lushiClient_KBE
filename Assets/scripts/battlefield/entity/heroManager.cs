using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroManager : MonoBehaviour {
    public static heroManager manager;
    public singleHeroController[] heros;
    private void Awake()
    {
        manager = this;
    }
    public void getRenderObj(bool isSelf, SceneEntityObject obj)
    {
        if (isSelf)
        {
            obj.getRenderObj(heros[0]);
        }
        else
        {
            obj.getRenderObj(heros[1]);
        }
    }
}
