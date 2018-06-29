using UnityEngine;
using KBEngine;
using System.Collections;
using System;
using System.Xml;
using System.Collections.Generic;

public class KBEEventProc:MonoBehaviour{

	public static KBEEventProc kbeEventProc;
	public static int currentPlayerID = 0;
	public static int useCardSumInRound = 0;
	public static Dictionary<int, SceneEntityObject> entityDic = new Dictionary<int, SceneEntityObject>();

	void Awake()
	{
		kbeEventProc = this;
		installEvents();
	}

	public void reqHasEnteredBattlefiled()
	{
		Account Me = KBEngine.KBEngineApp.app.player() as Account;
		if (Me != null)
		{
			print("报告已经进入battlefield");
			Me.baseCall("reqHasEnteredBattlefiled");
		}
	}


	/// <summary>
	/// 1.获取当前玩家的playerID
	/// 2.创建一个SceneEntityObject 作为Entity的renderObj
	/// </summary>
	/// <param name="entity"></param>
	public void onEnterWorld(KBEngine.Entity entity)
	{
		Debug.Log("实体进入世界 KBEEventProc：：onEnterWorld  entityID："+entity.id);
		if (entity.renderObj != null)
		{
			Debug.LogWarning("实体已经有renderObj 无法再次进入");
			return;
		}

		SceneEntityObject obj = new SceneEntityObject();
		obj.kbentity = entity;
        entity.renderObj = obj;


        if (entity.isPlayer())
		{
			currentPlayerID = Convert.ToInt16(entity.getDefinedProperty("playerID"));
		}
		else
		{

		}

		obj.onEnterWorld(entity.getDefinedProperty("playerID"));
	}

	public void onLeaveWorld(KBEngine.Entity entity)
	{


	}



	public void updateProperty(Entity entity)
	{
		set_playerID(entity);
		set_att(entity);
		set_cost(entity);
		set_frozen(entity);
		set_HP(entity);
		set_immune(entity);
		set_isAbled(entity);
		set_isDivineShield(entity);
		set_isRush(entity);
		set_isStealth(entity);
		set_isTaunt(entity);
		set_isWindfury(entity);
		set_maxHP(entity);
		set_cardID(entity);
		set_armor(entity);
		set_pos(entity);
	}

	public bool hasRenderObj(Entity entity)
	{
		if(entity.renderObj == null)
		{
			Debug.Log("KBEEventProc::nohasRenderObj entity:" + entity.id);
			onEnterWorld(entity);
			return false;
		}
		else
		{
			return true;
		}
	}

	
	public void set_playerID(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;

		target.set_playerID(entity.getDefinedProperty("playerID"));
	}
	public void set_HP(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
        Debug.Log("设置hp" + entity.getDefinedProperty("HP").ToString());
		target.set_HP(entity.getDefinedProperty("HP"));
	}
	public void set_armor(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;

		target.set_armor(entity.getDefinedProperty("armor"));
	}

	public void set_cardID(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;

		target.set_cardID(entity.getDefinedProperty("cardID"));
	}

	public void set_pos(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;

		target.set_pos(entity.getDefinedProperty("pos"));
	}

	public void set_cost(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_cost(entity.getDefinedProperty("cost"));
	}

	public void set_att(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_att(entity.getDefinedProperty("att"));
	}

	public void set_maxHP(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_maxHP(entity.getDefinedProperty("maxHP"));
	}
	public void set_isTaunt(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_isTaunt(entity.getDefinedProperty("isTaunt"));
	}
	public void set_isRush(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_isRush(entity.getDefinedProperty("isRush"));
	}
	public virtual void set_isWindfury(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_isWindfury(entity.getDefinedProperty("isWindfury"));
	}
	public void set_isDivineShield(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_isDivineShield(entity.getDefinedProperty("isDivineShield"));
	}
	public void set_isAbled(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_isAbled(entity.getDefinedProperty("isAbled"));

	}
	public void set_isStealth(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_isStealth(entity.getDefinedProperty("isStealth"));
	}
	public void set_frozen(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_frozen(entity.getDefinedProperty("frozen"));
	}
	public void set_immune(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_immune(entity.getDefinedProperty("immune"));
	}
	public void set_CrystalAvaliable(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_CrystalAvaliable(entity.getDefinedProperty("CrystalAvaliable"));
	}
	public void set_CrystalSum(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_CrystalSum(entity.getDefinedProperty("CrystalSum"));
	}
	public void set_KZsum(KBEngine.Entity entity, object v = null)
	{

	}
	public void set_nameA(KBEngine.Entity entity, object v = null)
	{

	}
	public void set_situation(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_situation(entity.getDefinedProperty("situation"));
	}
	public void set_afterTime(KBEngine.Entity entity, object v = null)
	{

	}

	public void set_useSum(KBEngine.Entity entity, object v = null)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.set_useSum(entity.getDefinedProperty("useSum"));
	}

	public void installEvents()
	{
		KBEngine.Event.registerOut("set_CrystalAvaliable", this, "set_CrystalAvaliable");
		KBEngine.Event.registerOut("set_CrystalSum", this, "set_CrystalSum");
		KBEngine.Event.registerOut("set_KZsum", this, "set_KZsum");
		KBEngine.Event.registerOut("set_nameA", this, "set_nameA");
		KBEngine.Event.registerOut("set_situation", this, "set_situation");
		KBEngine.Event.registerOut("set_afterTime", this, "set_afterTime");
		KBEngine.Event.registerOut("onEnterWorld", this, "onEnterWorld");
		KBEngine.Event.registerOut("onLeaveWorld", this, "onLeaveWorld");
		KBEngine.Event.registerOut("set_playerID", this, "set_playerID");
		KBEngine.Event.registerOut("set_att", this, "set_att");
		KBEngine.Event.registerOut("set_frozen", this, "set_frozen");
		KBEngine.Event.registerOut("set_HP", this, "set_HP");
		KBEngine.Event.registerOut("set_immune", this, "set_immune");
		KBEngine.Event.registerOut("set_isAbled", this, "set_isAbled");
		KBEngine.Event.registerOut("set_isDivineShield", this, "set_isDivineShield");
		KBEngine.Event.registerOut("set_isRush", this, "set_isRush");
		KBEngine.Event.registerOut("set_isStealth", this, "set_isStealth");
		KBEngine.Event.registerOut("set_isTaunt", this, "set_isTaunt");
		KBEngine.Event.registerOut("set_isWindfury", this, "set_isWindfury");
		KBEngine.Event.registerOut("set_maxHP", this, "set_maxHP");
		KBEngine.Event.registerOut("set_cardID", this, "set_cardID");
		KBEngine.Event.registerOut("set_armor", this, "set_armor");
		KBEngine.Event.registerOut("set_pos", this, "set_pos");
		KBEngine.Event.registerOut("set_cost", this, "set_cost");
		KBEngine.Event.registerOut("set_direction", this, "kong");
		KBEngine.Event.registerOut("set_position", this, "kong");
		KBEngine.Event.registerOut("onAtt", this, "onAtt");

	}

    public void kong(object obj = null)
    {

    }

	public virtual void onAtt(KBEngine.Entity entity, Int32 targetID)
	{
		if (!hasRenderObj(entity)) { return; }
		SceneEntityObject target = (SceneEntityObject)entity.renderObj;
		target.onAtt(targetID);
	}


}
