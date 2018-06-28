using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class BFcontroller : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Account Me = KBEngineApp.app.player() as Account;
        if(Me != null)
        {
            Me.baseCall("reqEnterBattlefield");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
