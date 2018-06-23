using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleShoucangCardController : MonoBehaviour {
    public cardDisplayController cdc;
    private void Start()
    {
        cdc = GetComponent<cardDisplayController>();
    }
    public void click()
    {
        shoucangManager.main.getChooseCard(cdc.cardIdStore);
    }

}
