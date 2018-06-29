using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour {

    public static weaponManager manager;
    public singleWeaponController[] weapons;
    private void Awake()
    {
        manager = this;
    }
    public void getRenderObj(bool isSelf,SceneEntityObject obj)
    {
        if (isSelf)
        {
            weapons[0].gameObject.SetActive(true);
            obj.getRenderObj(weapons[0]);
        }
        else
        {
            weapons[1].gameObject.SetActive(true);
            obj.getRenderObj(weapons[1]);
        }
    }
}
