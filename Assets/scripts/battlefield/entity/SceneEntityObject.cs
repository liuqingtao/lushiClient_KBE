using UnityEngine;
using KBEngine;
using System.Collections;
using System;
using System.Xml;
using System.Collections.Generic;

public class SceneEntityObject
{

	public Entity kbentity = null;
	public clientEntity renderObj = null;
    public int playerID;
	public bool isSelf
    {
        get
        {
            return playerID == KBEEventProc.currentPlayerID;
        }
    }
	public int entityID;
	private string oldPos = "";

	/// <summary>
	/// 1.储存playerID
	/// </summary>
	/// <param name="playerIDdata"></param>
	public void onEnterWorld(object playerIDdata)
	{
		if (kbentity == null)
		{
			Debug.LogError("进入世界失败，没有kbengine实体");           
			return;
		}

		Debug.Log("新实体创建成功 正在进入世界");

		playerID = Convert.ToInt16(playerIDdata.ToString());

		entityID = kbentity.id;
		KBEEventProc.entityDic.Add(entityID, this);
        KBEEventProc.kbeEventProc.updateProperty(kbentity);
    }



	public void set_pos(object data)
	{
        Debug.Log("sceneEntityObject::set_pos:"+data.ToString());

        if(data.ToString() == "KZ")
        {
            return;
        }

		/*
		self.pos
		HAND		手牌
		KZ			卡组中
		0-6			场上1-7号
		HERO		英雄
		WEAPON		武器
		SKILL		技能
		DEAD		死过的卡（随从）
		USED		用过的卡（法术）
		*/
		string pos = data.ToString();
		Debug.LogFormat("sceneEntityObject::set_pos::开始判断 pos：{0}  oldPos:{1}",pos,oldPos);
		if (pos == oldPos)
		{
			if (renderObj != null)
			{
				renderObj.set_pos(data.ToString());
				Debug.Log("sceneEntityObject::set_pos退出 原因：pos与之前相同");
                return;
            }
		}
		else
		{
			if (common.IsInt(pos) && common.IsInt(oldPos))
			{
				if (renderObj != null)
				{
					renderObj.set_pos(data.ToString());
				}
				else
				{
					noDis();
				}
				oldPos = pos;
				Debug.Log("sceneEntityObject::set_pos退出 原因：pos与oldpos均为随从");
				return;
			}
			else
			{
				oldPos = pos;
				noDis();
			}		
		}
		Debug.LogFormat("sceneEntityObject::set_pos::pos检测发生变化，重新开始显示 entityID:{0} pos:{1}",entityID,data.ToString());
		switch (pos)
		{
			case "KZ":
			case "DEAD":
			case "USED":
			case "N":
				break;
			case "HAND":
				handDis();
				break;
			case "WEAPON":
				weaponDis();
				break;
			case "SKILL":
				skillDis();
				break;
			case "HERO":
				heroDis();
				break;
			case "1":
			case "2":
			case "3":
			case "4":
			case "5":
			case "6":
			case "0":
				followerDis(pos);
				break;
			default:
				Debug.LogError("SceneEntityObject::pos分配失败，pos：" + pos + "ENTITY TYPE:" + kbentity.className + "ENTITY ID:" + kbentity.id);
				break;
		}

		if (renderObj != null)
		{
			renderObj.set_pos(data.ToString());
		}
	}

    public void followerDis(string pos)
    {
        Debug.Log("followerDis:"+pos);
        followerManagerMain.manager.getRenderObj(isSelf, this);
    }

    public void heroDis()
    {
       heroManager.manager.getRenderObj(isSelf, this);
    }

    public void skillDis()
    {
        skillManager.manager.getRenderObj(isSelf, this);
    }


    public void weaponDis()
    {
        weaponManager.manager.getRenderObj(isSelf, this);
    }

    public void handDis()
    {
        cardManager.manager.getRenderObj(isSelf, this);
    }


    public void noDis()
	{
		if (renderObj == null) return;
		renderObj.noDis();
		renderObj = null;
		
	}
	public bool checkEntity()
	{
		if (renderObj == null)
		{
			if (kbentity == null)
			{
				noDis();
				Debug.LogError("没有KBENGINE实体");
			}
            Debug.LogWarning("检测到渲染实体为空 将要创建 id：" + kbentity.id);
            KBEEventProc.kbeEventProc.set_pos(kbentity);			
			return false;
		}
		else
		{
            switch (oldPos)
            {
                case "KZ":
                case "DEAD":
                case "USED":
                case "":
                case "N":
                    return false;
            }
            return true;
		}
	}


	public void getRenderObj(clientEntity obj)
	{
		renderObj = obj;
        if(obj  == null)
        {
            Debug.LogError("clientEntity为空");
            return;
        }
		obj.sceneEntity = this;
		onGetRenderObj();
	}

	public void onGetRenderObj()
	{
		KBEEventProc.kbeEventProc.updateProperty(kbentity);
	}

	public void set_HP(object data)
	{
		if (!checkEntity()) { return; }
		renderObj.set_HP(data.ToString());
    }

	public void set_att(object data)
	{
		if(!checkEntity()){return;}
		renderObj.set_att(data.ToString());
	}

	public void set_playerID(object data)
	{
		playerID = Convert.ToInt16(data.ToString());

		if (!checkEntity()){return;}
		renderObj.set_playerID(data.ToString());

	}

	public void set_armor(object data)
	{
		if(!checkEntity()){return;}
		renderObj.set_armor(data.ToString());
	}

	public void set_cardID(object data)
	{
		if(!checkEntity()){return;}
		renderObj.set_cardID(data.ToString());
	}

	public void set_maxHP(object data)
	{
		if(!checkEntity()){return;}
		renderObj.set_maxHP(data.ToString());

	}
	public void set_isTaunt(object data)
	{
		if(!checkEntity()){return;}
		renderObj.set_isTaunt(data.ToString());

	}
	public void set_isRush(object data)
	{
		if(!checkEntity()){return;}
		renderObj.set_isRush(data.ToString());

	}
	public void set_isWindfury(object data)
	{
		if(!checkEntity()){return;}
		renderObj.set_isWindfury(data.ToString());

	}
	public void set_isDivineShield(object data)
	{
		if(!checkEntity()){return;}
		renderObj.set_isDivineShield(data.ToString());
	}
	public void set_isAbled(object data)
	{
		if(!checkEntity()){return;}
		renderObj.set_isAbled(data.ToString());

	}
	public void set_isStealth(object data)
	{
		if(!checkEntity()){return;}
		renderObj.set_isStealth(data.ToString());

	}
	public void set_frozen(object data)
	{
		if(!checkEntity()){return;}
		renderObj.set_frozen(data.ToString());

	}
	public void set_immune(object data)
	{
		if(!checkEntity()){return;}
		renderObj.set_immune(data.ToString());
	}

	public void set_cost(object data)
	{
		if (!checkEntity()) { return; }
		renderObj.set_cost(data.ToString());
	}

	public void set_useSum(object data)
	{
		if (!checkEntity()) { return; }
		renderObj.set_useSum(data.ToString());
	}

	public void set_CrystalAvaliable(object data)
	{
		if (isSelf)
		{
			//crystalManager.manager.selfActiveStore = int.Parse(data.ToString());
		}
		else
		{
            //crystalManager.manager.oppoActiveStore = int.Parse(data.ToString());
		}
       // crystalManager.manager.updateDisplay();
    }
	public void set_CrystalSum(object data)
	{
		if (isSelf)
		{
            //crystalManager.manager.selfSumStore = int.Parse(data.ToString());
		}
		else
		{
           // crystalManager.manager.oppoSumStore = int.Parse(data.ToString());
		}
        //crystalManager.manager.updateDisplay();
	}


	public void set_situation(object data)
	{
		if (isSelf)
		{

		}
	}

	public void onAtt(Int32 targetID)
	{
		if (!checkEntity()) { return; }
		//renderObj.onAtt(targetID);
	}


}
