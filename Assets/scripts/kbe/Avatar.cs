namespace KBEngine
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using KBEngine;

    public class Avatar : cardBase
    {
        public override void __init__()
        {
            base.__init__();
            Debug.Log("登陆成功 Avatar");
        }
        public void battleEnd(object success)
        {
            KBEngine.Event.fireOut("battleEnd", success);
        }
        public void set_CrystalSum(object old)
        {
            object v = getDefinedProperty("CrystalSum");
            Debug.Log(className + "::set_CrystalSum: " + old + " => " + v);
            Event.fireOut("set_CrystalSum", new object[] { this, v }); checkEntity();

        }
        public void set_CrystalAvaliable(object old)
        {
            object v = getDefinedProperty("CrystalAvaliable");
            Debug.Log(className + "::set_CrystalAvaliable: " + old + " => " + v);
            Event.fireOut("set_CrystalAvaliable", new object[] { this, v }); checkEntity();

        }

    }

}

