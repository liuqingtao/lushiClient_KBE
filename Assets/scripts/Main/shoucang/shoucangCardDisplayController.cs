using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoucangCardDisplayController : MonoBehaviour {

    public GameObject[] cardDisplayList;

    public void displayCard(List<uint> ls)
    {
        int displaySum = ls.Count;
        if (displaySum > 8)
        {
            return;
        }
        for(int i = 0; i < 8; i++)
        {
            cardDisplayList[i].SetActive(i < displaySum);
            if (i < displaySum)
            {
                cardDisplayList[i].GetComponent<cardDisplayController>().setCard(ls[i]);
            }
        }

    }
    private void OnGUI0()
    {
        if (Input.GetKey(KeyCode.L))
        {
            List<uint> ls = new List<uint>();
            for(int i = 0; i < 7; i++)
            {
                ls.Add((uint)(10000001 + i));
            }
            displayCard(ls);
        }
    }
}
