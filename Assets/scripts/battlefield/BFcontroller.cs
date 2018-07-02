using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class BFcontroller : MonoBehaviour {
    public static BFcontroller manager;
    public clientEntity recvTargetObj;
    public int state = 0;
    //0 不是自己的回合不能出牌  1 自己的回合可以自由出牌 2 自己回合中正在选择出牌的目标 3 自己回合选择攻击的目标
    // Use this for initialization
    private void Awake()
    {
        manager = this;
    }
    void Start () {
        Account Me = KBEngineApp.app.player() as Account;
        if(Me != null)
        {
            Me.baseCall("reqEnterBattlefield");
        }
	}
	
	public void getUseTarget(clientEntity e)
    {
        if (state != 1)
        {
            return;
        }
        state = 2;
        recvTargetObj = e;
    }

    public void getAttTarget(clientEntity e)
    {
        if (state != 1)
        {
            return;
        }
        state = 3;
        recvTargetObj = e;
    }
    public void onClickEntity(clientEntity e)
    {
        if (state == 2)
        {
            recvTargetObj.reqUse(e.id);
        }
        else if(state == 3)
        {
            recvTargetObj.reqAtt(e.id);
        }
        else if (state == 1)
        {
            getAttTarget(e);
        }
    }
    public void endRound()
    {
        if (state == 0)
        {
            return;
        }
        KBEngine.Avatar avatar = KBEngineApp.app.player() as KBEngine.Avatar;
        if(avatar != null)
        {
           avatar.cellCall("reqEndRound");
        }
        
    }
    public void giveUp()
    {
        
        KBEngine.Avatar avatar = KBEngineApp.app.player() as KBEngine.Avatar;
        if (avatar != null)
        {
            avatar.cellCall("reqGiveUp");
        }

    }

}
