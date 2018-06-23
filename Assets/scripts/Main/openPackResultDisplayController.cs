using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPackResultDisplayController : MonoBehaviour {

    public GameObject[] pack;
    public GameObject button;

    public void display(List<uint> cadIDLIST)
    {
        Display(true);
        for(int i = 0; i < 5; i++)
        {
            pack[i].GetComponent<cardDisplayController>().setCard(cadIDLIST[i]);
        }
    }
    public void Display(bool dis)
    {
        foreach(GameObject obj in pack)
        {
            obj.SetActive(dis);
        }
        button.SetActive(dis);
    }
    private void OnGUI()
    {
        if (Input.GetKey(KeyCode.O))
        {
            List<uint> LS = new List<uint>();
            for(int i = 1; i < 6; i++)
            {
                LS.Add((uint)(10000000 + i));
            }
            display(LS);
        }
    }

}
