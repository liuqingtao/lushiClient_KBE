using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillManager : MonoBehaviour {
    public static skillManager manager;
    public singleHeroSkillController[] skills;
    private void Awake()
    {
        manager = this;
    }
    public void getRenderObj(bool isSelf, SceneEntityObject obj)
    {
        if (isSelf)
        {
            skills[0].gameObject.SetActive(true);
            obj.getRenderObj(skills[0]);
        }
        else
        {
            skills[1].gameObject.SetActive(true);
            obj.getRenderObj(skills[1]);
        }
    }

}
