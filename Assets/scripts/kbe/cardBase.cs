namespace KBEngine
{

	using UnityEngine;
	using System.Collections.Generic;
	using System;

	public class cardBase : Entity
	{
		public List<Dictionary<string, object>> eventList = new List<Dictionary<string, object>>();


		public void checkEntity()
		{
			if (renderObj == null)
			{
				enterWorld();
			}

		}
		public void set_playerID(object old)
		{
			object v = getDefinedProperty("playerID");
			Debug.Log(className + "::set_playerID: " + old + " => " + v); 
			Event.fireOut("set_playerID", new object[] { this, v });checkEntity();

		}
		public void set_HP(object old)
		{
			object v = getDefinedProperty("HP");
			Debug.Log(className + "::set_HP: " + old + " => " + v); 
			Event.fireOut("set_HP", new object[] { this, v });checkEntity();
		}
		public void set_armor(object old)
		{
			object v = getDefinedProperty("armor");
			//Debug.Log(className + "::set_armor: " + old + " => " + v); 
			Event.fireOut("set_armor", new object[] { this, v });checkEntity();
		}

		public void set_cardID(object old)
		{
			object v = getDefinedProperty("cardID");
			Debug.Log(className + "::set_cardID: " + old + " => " + v); 
			Event.fireOut("set_cardID", new object[] { this, v });checkEntity();
		}

		public void set_cost(object old)
		{
			object v = getDefinedProperty("cost");
			//Debug.Log(className + "::set_cost: " + old + " => " + v); 
			Event.fireOut("set_cost", new object[] { this, v });checkEntity();
		}

		public void set_att(object old)
		{

			object v = getDefinedProperty("att");
			//Debug.Log(className + "::set_att: " + old + " => " + v); 
			Event.fireOut("set_att", new object[] { this, v });checkEntity();
		}

		public void set_maxHP(object old)
		{

			object v = getDefinedProperty("maxHP");
			//Debug.Log(className + "::set_maxHP: " + old + " => " + v); 
			Event.fireOut("set_maxHP", new object[] { this, v });checkEntity();
		}
		public void set_isTaunt(object old)
		{

			object v = getDefinedProperty("isTaunt");
			//Debug.Log(className + "::set_isTaunt: " + old + " => " + v); 
			Event.fireOut("set_isTaunt", new object[] { this, v });checkEntity();
		}
		public void set_isRush(object old)
		{

			object v = getDefinedProperty("isRush");
			//Debug.Log(className + "::set_isRush: " + old + " => " + v); 
			Event.fireOut("set_isRush", new object[] { this, v });checkEntity();
		}
		public void set_isWindfury(object old)
		{

			object v = getDefinedProperty("isWindfury");
			//Debug.Log(className + "::set_isWindfury: " + old + " => " + v); 
			Event.fireOut("set_isWindfury", new object[] { this, v });checkEntity();
		}
		public void set_isDivineShield(object old)
		{

			object v = getDefinedProperty("isDivineShield");
			//Debug.Log(className + "::set_isDivineShield: " + old + " => " + v); 
			Event.fireOut("set_isDivineShield", new object[] { this, v });checkEntity();
		}
		public void set_isAbled(object old)
		{

			object v = getDefinedProperty("isAbled");
			//Debug.Log(className + "::set_isAbled: " + old + " => " + v); 
			Event.fireOut("set_isAbled", new object[] { this, v });checkEntity();
		}
		public void set_isStealth(object old)
		{

			object v = getDefinedProperty("isStealth");
			//Debug.Log(className + "::set_isStealth: " + old + " => " + v); 
			Event.fireOut("set_isStealth", new object[] { this, v });checkEntity();
		}
		public void set_frozen(object old)
		{

			object v = getDefinedProperty("frozen");
			//Debug.Log(className + "::set_frozen: " + old + " => " + v); 
			Event.fireOut("set_frozen", new object[] { this, v });checkEntity();
		}
		public void set_immune(object old)
		{

			object v = getDefinedProperty("immune");
			//Debug.Log(className + "::set_immune: " + old + " => " + v); 
			Event.fireOut("set_immune", new object[] { this, v });checkEntity();
		}

		public void set_pos(object old)
		{

			object v = getDefinedProperty("pos");
			Debug.Log(className + "::set_pos: " + old + " => " + v); 
			Event.fireOut("set_pos", new object[] { this, v });checkEntity();
		}

		public void set_useSum(object old)
		{

			//object v = getDefinedProperty("useSum");
			//Debug.Log(className + "::set_useSum: " + old + " => " + v);
			//Event.fireOut("set_useSum", new object[] { this, v }); checkEntity();
		}


		public void onAtt(Int32 targetID)
		{
			Dbg.DEBUG_MSG(className + "::onAtt: " + targetID);
			Event.fireOut("onAtt", new object[] { this, targetID });
		}

		public void onUse(Int32 targetID)
		{
			Dbg.DEBUG_MSG(className + "::onUse: " + targetID);
			Event.fireOut("onUse", new object[] { this, targetID });
		}
	
		public void onEvent(Int32 targetID,int damage,string infor)
		{
			Dbg.DEBUG_MSG(className + "::onEvent: " + targetID + "damage:"+damage + "infor:" + infor);
			Dictionary<string, object> eventDic = new Dictionary<string, object>();
			eventDic.Add("targetID", targetID);
			eventDic.Add("damage", damage);
			eventDic.Add("infor", infor);
			eventList.Add(eventDic);
		}

		public void reqUse(int targetID)
		{
			cellCall("reqUse", targetID);
            Debug.Log("reqUse targetID:" + targetID);
		}

        public void reqAtt(int targetID)
        {
            cellCall("reqAtt", targetID);
            Debug.Log("reqAtt targetID:" + targetID);
        }

 




	}
}
