using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class crystalManager : MonoBehaviour {

    public crystalDisplayController cdc;
    public Text[] displayTexts;
    public int selfSumStore;
    public int selfActiveStore;
    public int oppoSumStore;
    public int oppoActiveStore;
    public void setCrystal(int selfSum,int selfActive,int oppoSum,int oppoActive)
    {
        if (selfSum > -1)
        {
            selfSumStore = selfSum;
        }
        if (selfActive > -1)
        {
            selfActiveStore = selfActive;
        }
        if (oppoSum > -1)
        {
            oppoSumStore = oppoSum;
        }
        if (oppoActive > -1)
        {
            oppoActiveStore = oppoActive;
        }
        updateDisplay();
    }
    public void updateDisplay()
    {
        displayTexts[0].text = string.Format("{0}/{1}", selfActiveStore, selfSumStore);
        displayTexts[1].text = string.Format("{0}/{1}", oppoActiveStore, oppoSumStore);
        cdc.setCrystalDisplay(selfSumStore, selfActiveStore);
    }
    private void Start()
    {
        
    }
    private void OnGUI()
    {
        if (Input.GetKey(KeyCode.W))
        {
            setCrystal(8, 5, 7, 1);
        }
    }
}
